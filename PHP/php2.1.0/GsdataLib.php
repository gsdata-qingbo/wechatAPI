<?php

/**
 * 功能：清博指数平台接口实现
 * 版本：2.1.0
 * 修改日期：2016-08-31
 */
class GsdataLib
{

    const URL = 'http://open.gsdata.cn/api/';
    const APP_ID = '';
    const APP_KEY = '';

    /**
     * 处理接口的返回值，并进行验签，如果返回值不合法或者验签失败，则返回错误提示
     * @param string $url 接口地址
     * @param array $param 传递参数
     * @param bool $raw 是否原样输出
     * @return mixed
     */
    public function call($url, $param = array(), $raw = true)
    {
        $param['appid'] = self::APP_ID;
        $param['signature'] = $this->signature($param);
        $post_string = base64_encode($this->json_encode($param));
        $content = $this->fetch(self::URL . '/' . $url, $post_string, 'post');
        if ($raw) {
            return $content;
        } else {
            return json_decode($content, true);
        }
    }

    /**
     * 接口的数据签名生成方法
     * @param array $data
     * @return string
     */
    protected function signature($data)
    {
        ksort($data, SORT_STRING);
        return md5(strtolower($this->json_encode($data)) . self::APP_KEY);
    }

    /**
     * @param $url
     * @param array $params array or string
     * @param string $method
     * @param array $header
     * @return mixed
     */
    protected static function fetch($url, $params = array(), $method = "get", $header = array())
    {
        $ch = curl_init();
        if (is_array($params)) {
            $query = http_build_query($params);
        } else {
            $query = $params;
        }
        if ($method == 'get') {
            if (strpos($url, '?') !== false) {
                $url .= "&" . $query;
            } else {
                $url .= "?" . $query;
            }
        } else {
            curl_setopt($ch, CURLOPT_POST, 1);
            curl_setopt($ch, CURLOPT_POSTFIELDS, $query);
        }
        curl_setopt($ch, CURLOPT_URL, $url);
        curl_setopt($ch, CURLOPT_HTTPHEADER, $header);
        curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
        curl_setopt($ch, CURLOPT_CONNECTTIMEOUT, 5);
        curl_setopt($ch, CURLOPT_TIMEOUT, 5);
        curl_setopt($ch, CURLOPT_SSL_VERIFYHOST, 0);
        curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, 0);
        $data = curl_exec($ch);
        curl_close($ch);

        return $data;
    }

    protected function json_encode($input)
    {
        return str_replace('\/', '/', json_encode($input));
    }

}

package cn.gsdata.index;

import cn.gsdata.index.ApiSdk;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by shiyq on 15-5-18.
 */
public class ApiDemo {

	private final static String appId = "";// 你的appId
	private final static String appKey = "";// 你的appKey
	
	private final static String host = "http://open.gsdata.cn/api";// 默认域名

	public static void main(String[] args) {
		try {
			// 获取ApiSdk 单例对象
			ApiSdk apiSdk = ApiSdk.getApiSdk(appId, appKey);

			/*
			 * 参数集合 此处参数不需要加appid和appkey,因为上面构造单例对象时，已经默认加上了，
			 * 如果使用非单例对象模式，在下面参数集合中需要 加上appid和appkey
			 */
			Map<String, Object> map = new HashMap<String, Object>();
			map.put("loginname", "superadmin");// 参数1
			// map.put("p2", "xxxx");//参数2
			// ....
			// ....
			// map.put("pn", "xxxx");//参数n

			// 调用接口
			String ret_json = apiSdk.callInterFace(host + "/sys/sysapi/user_info2", map);
			System.out.println("返回:" + ret_json);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}

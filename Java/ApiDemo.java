package cn.gsdata.index;

import cn.gsdata.index.ApiSdk;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by shiyq on 15-5-18.
 */
public class ApiDemo {

	private final static String appId = "";// ���appId
	private final static String appKey = "";// ���appKey
	
	private final static String host = "http://open.gsdata.cn/api";// Ĭ������

	public static void main(String[] args) {
		try {
			// ��ȡApiSdk ��������
			ApiSdk apiSdk = ApiSdk.getApiSdk(appId, appKey);

			/*
			 * �������� �˴���������Ҫ��appid��appkey,��Ϊ���湹�쵥������ʱ���Ѿ�Ĭ�ϼ����ˣ�
			 * ���ʹ�÷ǵ�������ģʽ�������������������Ҫ ����appid��appkey
			 */
			Map<String, Object> map = new HashMap<String, Object>();
			map.put("loginname", "superadmin");// ����1
			// map.put("p2", "xxxx");//����2
			// ....
			// ....
			// map.put("pn", "xxxx");//����n

			// ���ýӿ�
			String ret_json = apiSdk.callInterFace(host + "/sys/sysapi/user_info2", map);
			System.out.println("����:" + ret_json);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}

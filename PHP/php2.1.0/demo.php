<?php

/**
 * @desc 此demo为测试调去数据的方式
 * 获取用户信息
 */
include('GsdataLib.php');
$gsdata = new GsdataLib;
$param = array('loginname' => 'XXXXX@qq.com');
//$data=$gsdata->call('sys/sysapi/user_info',$param);
//print_r($data);
$data = $gsdata->call('wx/opensearchapi/content_keyword_search',array(
			'startdate' => date('2015-10-01'),
			'enddate' => date('Y-m-d'),
			'keyword' => '万达',
	));
print_r($data);

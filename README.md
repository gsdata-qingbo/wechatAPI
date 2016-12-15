# wechatAPI

http://app.gsdata.cn/apidoc/apiopen

微信API 北京清博大数据科技有限公司

可以通过调用这里的API获取微信公众号数据；我们对62万个微信公众号进行每天数据采集，采集内容包括文章标题、文章摘要、公众号名称、文章阅读量、点赞量等。可以通过API按词搜索微信文章，也可以按公众号和日期搜索文章。API提供10个月的历史数据。


Wechat API
Beijing Qingbo Big Data Science & Technology Co. Ltd.

We provide Wechat API to access Wechat public pages. You can get article titles, article body text, abstracts, authors, reading counts, and like counts, etc. The data is updated every 24 hours, covering 620,000 Wechat public subscribe accounts as well as service accounts. You can search by words or by account names with date ranges. As early as 10-months-from-present history data is available. 


系统API（接口列表）

/api/sys/sysapi/user_info 	根据用户名称查询用户信息

/api/sys/sysapi/login_user 	用户登陆验证

/api/sys/sysapi/check_user 	用户名验证


微信API（接口列表）

/api/wx/wxapi/del_nickname_In_group 	删除本用户分组内微信公众号

/api/wx/wxapi/del_wxname_In_group 	用户根据wx_name删除分组内账号

/api/wx/wxapi/getYGFS 	获取账号预估粉丝数

/api/wx/wxapi/wx_week_readnum 	通过本系统nickname_id或微信文章url地址获取距发布时间七日时间阅读点赞数

/api/wx/wxapi/group_name 	获取用户下所有微信分组信息

/api/wx/wxapi/nickname_one 	获取一个公众号的信息

/api/wx/wxapi/nickname_result 	通过markid、day返回分页统计标签排行

/api/wx/wxapi/nickname_mark 	通过nicknameid返回在不同标签下的排行名次

/api/wx/wxapi/all_mark 	返回所有标签

/api/wx/wxapi/result_tables 	返回当月所有统计表（日，周）

/api/wx/wxapi/nickname 	通过UID返回用户分组及各分组内的公众号(含最新发布的一条文章)列表

/api/wx/wxapi/group_data 	通过groupid、day返回文章分页集合

/api/wx/wxapi/result_append 	通过groupid、day返回分页统计排行内样本总数量(公众号总数、发文总数、总阅读)

/api/wx/wxapi/result_day 	通过groupid、day返回分页统计DAY排行

/api/wx/wxapi/result_week 	通过groupid、day返回分页统计WEEK排行

/api/wx/wxapi/add_wx_to_group 	通过文章地址添加微信公众账号到分组

/api/wx/wxapi/add_wx_to_group2 	通过公众号、公众号昵称 添加公众号到分组

/api/wx/wxapi/wx_content 	实时获取公众号文章正文

/api/wx/wxapi/wx_content2 	实时获取文章正文(源码格式)以及其他信息

/api/wx/wxapi/wx_video_data 	微信热门视频数据

/api/wx/opensearchapi/nickname_order_now 	获取单个公众号最新排名情况

/api/wx/opensearchapi/nickname_order_list 	获取n天公众号的排名情况（默认3天）

/api/wx/opensearchapi/nickname_group 	通过分组编号（groupid）和appid的用户编号获取用户的分组和分组下公众号

/api/wx/opensearchapi/nickname_keyword_search 	使用关键字搜索公账号信息，搜索条件为wx_nickname OR wx_name

/api/wx/opensearchapi/nickname_keyword_search2 	使用关键字搜索公众，搜索条件为系统默认，结果与www.gsdata.cn 搜索结果基本一致

/api/wx/opensearchapi/content_keyword_search 	使用关键字搜索公众号文章

/api/wx/opensearchapi/content_list 	根据条件搜索公众号某段时间内的文章信息

/api/wx/opensearchapi/nickname_order_total 	获取某个公众号时间范围内的文章总数、阅读总数、点赞总数

/api/wx/wxapi2/wx_comment_by_url 	根据文章地址获取该文章的评论信息

/api/wx/wxapi/addWxGroup 	添加微信分组到用户账户下

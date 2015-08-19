
//全局API
var API = {};

//全局配置
API.Config = {
    SSOServer: "/common/login?callback=?", //SSO服务地址
    PersonTrace: "ReportPersonInfoGet" //人员信息跟踪
};

//获取URL参数
API.QueryString = function (val) {
    var result = location.search.match(new RegExp("[\?\&]" + val + "=([^\&]+)", "i"));
    if (result == null || result.length < 1) {
        return "";
    }
    return result[1];
};

//提交数据
API.Post = function (url, data, callback) {

    $.ajax({
        url: url,
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(data),
        success: function (response) {
            var json = response;//JSON.parse(response)
            if (jQuery.isFunction(callback)) {
                callback(json);
            }
        },
        error: function () {
            alert()
        }
    });
};


//封装提交数据， API.Reqest("SysUserGet",1);
API.Request = function (cmd, data, callback) {
    var url = "/System/Ajax/Request";

    if (typeof data == 'object') {
        data = JSON.stringify(data);
    }
    API.Post(url, { cmd: cmd, Data: data }, callback);
};


API.DateFormat = function(value) {
    if (value == null)
        return;

    var date = new Date(parseInt(value.replace(/\/Date\((-?\d+)\)\//, '$1')));
    var y = date.getFullYear();
    var m = date.getMonth() + 1;
    var d = date.getDate();

    var h = date.getHours();
    var mm = date.getMinutes();
    var ss = date.getSeconds();

    return y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
};

API.DateTimeFormat = function (value) {
    if (value == null)
        return;
    if (value.indexOf("Date") == -1) {
        return value;
    }

    var date = new Date(parseInt(value.replace(/\/Date\((-?\d+)\)\//, '$1')));
    var y = date.getFullYear();
    var m = date.getMonth() + 1;
    var d = date.getDate();

    var h = date.getHours();
    var mm = date.getMinutes();
    var ss = date.getSeconds();

    return y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d) + ' ' + h + ':' + mm;// + ':' + ss;
}


function formatterState(val, row) {
    if (val == 1)
        return "启用";
    else if (val == -1)
        return "禁用";
    else if(val == 2)
        return "删除";
};

function positionFormat(val, row) {
    if (val == 0)
        return "领导";
    else if (val == 1)
        return "投资顾问";
};




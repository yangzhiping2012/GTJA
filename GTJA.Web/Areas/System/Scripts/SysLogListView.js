var viewModel = function () {
    var self = this;
    self.dataGrid = new dataGrid($('#dg'));

    //初始化函数
    self.init = function () {

    };

    //刷新
    self.reload = function () {
        self.dataGrid.Reload();
    };

    //删除
    self.remove = function () {
        self.dataGrid.Remove("/System/Ajax/Request?cmd=SysLogRemove");
    };

    //检索
    self.doSearch = function () {
        var keywords = $("#keywords").val();
        var start = $("#startTime").datebox("getValue");
        var end = $("#endTime").datebox("getValue");
        self.dataGrid.search({ keywords: keywords, startTime: start, endTime: end });
    };
};

var vm = new viewModel();
$(function () {
    vm.init();
    $('#loading-mask').fadeOut();
});



function formatterLogType(val, row) {
    if (val == 1) {
        return "运行日志";
    }
    else if (val == 2)
        return "操作日志";

    return "其他";
}

function formatterEventType(val, row) {
    if (val == 1)
        return "浏览";
    else if (val == 2)
        return "新增";
    else if (val == 3)
        return "修改";
    else if (val == 4)
        return "删除";
    else if (val == 5)
        return "授权";
    else if (val == 6)
        return "异常";
    else if (val == 7)
        return "信息";
    else
        return "其他";

}

function formatterView(val, row) {
    return "<a onclick=\"showInfo(" + row.ID + ");\">查看</a>";
}

function showInfo(id) {
    var rows = $("#dg").datagrid("getRows");
    for (var i = 0; i < rows.length; i++) {
        if (rows[i].ID == id) {
            $.messager.show({ title: "信息", width: 600, height: 450, msg: rows[i].Description, timeout: 10000 });
            break;
        }
       
    }
   

}
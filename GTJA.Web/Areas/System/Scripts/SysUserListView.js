var viewModel = function () {
    var self = this;
    self.form = $("#form1");
    self.form2 = $("#form2");
    self.formDiv = $("#dlg");
    self.formDiv2 = $("#dlgPass");
    self.dataGrid = new dataGrid($('#dg'))

    //初始化函数
    self.init = function () {

    };

    //刷新
    self.reload = function () {
        self.dataGrid.Reload();
    };

    //新增
    self.add = function () {
        $("#LoginName").removeAttr("disabled");
        self.dataGrid.Add(self.form, self.formDiv);
    };

    //编辑
    self.edit = function (flag) {
        $("#LoginName").attr("disabled", "disabled");
        self.dataGrid.Edit(self.form, self.formDiv, function (data) {
            $("#LoginName").val(data.LoginName);
            $("#LoginName").validatebox('validate');
        });
    };

    //重置密码
    self.reset = function () {
        $("#LoginName").attr("disabled", "disabled");

        self.dataGrid.Edit(self.form2, self.formDiv2);
    }
    //删除
    self.remove = function () {
        self.dataGrid.Remove("/System/Ajax/Request?cmd=SysUserRemove");
    };

    //提交
    self.submit = function (flag) {
        if (flag == 0)
            self.dataGrid.Submit(self.form, self.formDiv, function (data) {
                if (data == "true") {
                    return true;
                }
                else if (data.indexOf("Exists") != -1) {
                    $.messager.alert("提示", "登陆帐号已经存在，请重新输入", "error");
                    return false;
                }
            });

        if (flag == 1)
            self.dataGrid.Submit(self.form2, self.formDiv2, function (data) {
                if (data == "true") {
                    return true;
                }
                else if (data.indexOf("Exists") != -1) {
                    $.messager.alert("提示", "登陆帐号已经存在，请重新输入", "error");
                    return false;
                }
            });
    };

    //检索
    self.doSearch = function () {
        var keywords = $("#keywords").val();
        self.dataGrid.search({ keywords: keywords });
    };

    //授权
    self.opengrant = function () {
        self.dataGrid.opentree($("#tree"), $("#dlgtree"), true, "/System/Ajax/Request?cmd=SysRoleTree");
    };
    //保存授权
    self.savegrant = function () {
        self.dataGrid.savetree($("#tree"), $("#dlgtree"), "/System/Ajax/Request?cmd=SysUserRoleAdd")
    };


};

var vm = new viewModel();
$(function () {
    vm.init();
    $('#loading-mask').fadeOut();
});


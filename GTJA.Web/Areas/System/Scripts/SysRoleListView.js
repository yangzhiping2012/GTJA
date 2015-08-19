var viewModel = function () {
    var self = this;
    self.form = $("#form1");
    self.formDiv = $("#dlg");
    self.dataGrid = new dataGrid($('#dg'));

    //初始化函数
    self.init = function () {

    };

    //刷新
    self.reload = function () {
        self.dataGrid.Reload();
    };

    //新增
    self.add = function () {
        self.dataGrid.Add(self.form, self.formDiv);
    };

    //编辑
    self.edit = function () {
        self.dataGrid.Edit(self.form, self.formDiv);
    };

    //删除
    self.remove = function () {
        self.dataGrid.Remove("/System/Ajax/Request?cmd=SysRoleRemove");
    };

    //提交
    self.submit = function () {
        self.dataGrid.Submit(self.form, self.formDiv, function (data) {
            if (data == "true") {
                return true;
            }
            else if (data == "") {
                //其他判重逻辑
                return false;
            }


        });
    };

    //授权
    self.opengrant = function () {
        self.dataGrid.opentree($("#tree"), $("#dlgtree"),true, "/System/Ajax/Request?cmd=SysModuleTree");
    };
    //保存授权
    self.savegrant = function () {
        self.dataGrid.savetree($("#tree"), $("#dlgtree"), "/System/Ajax/Request?cmd=SysRoleModuleAdd")
    };
};


var vm = new viewModel();
$(function () {

    vm.init();
    $('#loading-mask').fadeOut();
});




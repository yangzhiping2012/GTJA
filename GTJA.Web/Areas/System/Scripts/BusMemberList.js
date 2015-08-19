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
        self.dataGrid.Remove("/Member/Ajax/Request?cmd=BusMemberRemove");
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
    
    self.openImport = function () {
        $("#dlgImport").show();
        $("#dlgImport").window({}).window('open');
    };
    

    self.import = function () {
        $.messager.progress({ title: "导入会员信息", msg: "正在导入，可能需要等待几分钟才能完成！" });
        $("#form1").form('submit', {
            success: function (data) {
                if (data == "true") {
                    self.dataGrid.Reload();
                    $.messager.progress('close');
                    $("#dlgImport").window({}).window('close');
                }
                else {
                    $.messager.alert("导入失败", data, "error");
                    $.messager.progress('close');
                }
            }
        });
    };
};


var vm = new viewModel();
$(function () {

    vm.init();
    $('#loading-mask').fadeOut();
});




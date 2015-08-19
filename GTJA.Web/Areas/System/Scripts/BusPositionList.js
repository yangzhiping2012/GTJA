var viewModel = function () {
    var self = this;
    self.form = $("#form1");
    self.formDiv = $("#dlg");
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

        self.dataGrid.Add(self.form, self.formDiv);
    };

    //编辑
    self.edit = function (flag) {
       
        self.dataGrid.Edit(self.form, self.formDiv);
    };

    //删除
    self.remove = function () {
        self.dataGrid.Remove("/System/Ajax/Request?cmd=BusPositionRemove");
    };

    //提交
    self.submit = function (flag) {
            self.dataGrid.Submit(self.form, self.formDiv, function (data) {
                if (data == "true") {
                    return true;
                }
            });

    };

};

var vm = new viewModel();
$(function () {
    vm.init();
    $('#loading-mask').fadeOut();
});


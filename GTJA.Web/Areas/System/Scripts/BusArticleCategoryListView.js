var viewModel = function () {
    var self = this;
    self.form = $("#form1");
    self.formDiv = $("#dlg");
    self.dataGrid = new treeGrid($('#dg'));
    //初始化函数
    self.init = function () {

    };

    //刷新
    self.reload = function () {
        self.dataGrid.Reload();
    };

    self.add = function () {
        var treeData = JSON.parse(JSON.stringify($('#dg').treegrid('getData')).replace(/ID/g, "id").replace(/Name/g, "text"));
        $("#ParentID").combotree('loadData', treeData);
        
        self.dataGrid.Add(self.form, self.formDiv);
    };


    self.edit = function () {
        var treeData = JSON.parse(JSON.stringify($('#dg').treegrid('getData')).replace(/ID/g, "id").replace(/Name/g, "text"));
        $("#ParentID").combotree('loadData', treeData);
        self.dataGrid.Edit(self.form, self.formDiv);
    };

    self.remove = function() {
        self.dataGrid.Remove("/Member/Ajax/Request?cmd=BusArticleCategoryDelete");
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
};

var vm = new viewModel();
$(function () {
    vm.init();
    $('#loading-mask').fadeOut();
})
;


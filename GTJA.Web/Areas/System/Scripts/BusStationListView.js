var viewModel = function () {
    var self = this;
    self.form = $("#form1");
    self.formDiv = $("#dlg");
    self.dataGrid = new treeGrid($('#dg'))
    //初始化函数
    self.init = function () {

    };

    //刷新
    self.reload = function () {
        self.dataGrid.Reload();
    };

    //新增
    self.add = function () {
        var parentId = "";
        var selected = self.dataGrid.treegrid.treegrid('getSelected');
        if (selected != null &&undefined!=selected.ID) {
            parentId = selected.ID
        }
        var treeData = JSON.parse(JSON.stringify(self.dataGrid.treegrid.treegrid('getData')).replace(/ID/g, "id").replace(/Name/g, "text"));
        $("#ParentID").combotree('loadData', treeData);

        self.dataGrid.Add(self.form, self.formDiv, { ParentID: parentId });
    };

    //编辑
    self.edit = function (flag) {
        var treeData = JSON.parse(JSON.stringify(self.dataGrid.treegrid.treegrid('getData')).replace(/ID/g, "id").replace(/Name/g, "text"));
        $("#ParentID").combotree('loadData', treeData);
        $('#ParentID').combotree({
            onSelect: function (node) {
                if (node.id == $("#ID").val()) {
                    $.messager.alert('提示', '所选上级不能是本身！', 'warning');
                    $("#ParentID").combotree("clear");
                }
            }
        })
        self.dataGrid.Edit(self.form, self.formDiv);
    };
    //删除
    self.remove = function (flag) {
        self.dataGrid.Remove("/Member/Ajax/Request?cmd=BusStaionRemove");
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
})
;


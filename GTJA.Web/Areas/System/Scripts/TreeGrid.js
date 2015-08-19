
var treeGrid = function (treegrid) {
    var self = this;
    self.treegrid = treegrid;

    //刷新列表
    self.Reload = function () {
        self.treegrid.treegrid("reload");
    };

    //添加事件(data 可以是包含父节点的Json数据)
    self.Add = function (form, formDiv,data) {
        formDiv.show();
        //重置表单
        form.form("clear");
        form.form("load", data);
        //打开窗口
        formDiv.window({}).window('open');
    };

    //编辑事件
    self.Edit = function (form, formDiv, callback) {
        formDiv.show();
        //重置表单
        form.form("clear");
        //加载数据
        var data = self.SingleRow();
        if (data == null) return;

        //打开窗口
        formDiv.window({}).window('open');

        if (jQuery.isFunction(callback)) {
            callback(data);
        }

        form.form("load", data);
    };

    //删除事件
    self.Remove = function (url) {
        var row = self.SingleRow();
        if (row == null) return;
        var ids = [row.ID];
        $.messager.confirm('提示', '确定要删除吗?', function (r) {
            if (r) {
                $.messager.progress({});
                var data = { Data: JSON.stringify(ids) };
                $.ajax({
                    url: url,
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify(data),
                    success: function (response) {
                        self.Reload();
                        $.messager.progress('close');

                    }
                });

            }
        });
    };

    //提交表单
    self.Submit = function (form, formDiv, callback) {
        $.messager.progress({});
        form.form('submit', {
            onSubmit: function () {
                var valid = $(this).form('validate');
                if (!valid) {
                    $.messager.progress('close');
                }

                return valid;
            },
            success: function (data) {
                $.messager.progress('close');
                if (jQuery.isFunction(callback)) {
                    if (callback(data)) {
                        formDiv.window("close");
                        self.Reload();
                    }
                }
                else {
                    formDiv.window("close");
                    self.Reload();
                }
            }
        });

    };

    //单选
    self.SingleRow = function () {
        var slected = self.treegrid.treegrid('getSelected');
        if (slected==null) {
            $.messager.alert('提示', '请选中一条数据编辑！', 'warning');
        }
        return slected;
    };

};
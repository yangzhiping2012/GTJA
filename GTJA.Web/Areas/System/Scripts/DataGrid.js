
var dataGrid = function (datagrid) {
    var self = this;
    self.datagrid = datagrid;
    //刷新列表
    self.Reload = function (queryParams) {
        self.datagrid.datagrid("reload", queryParams);
    };

    //添加事件
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
        var data = self.SingleRow(datagrid);
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
        var rows = self.MultiRows();
        if (rows == null) return;
        var ids = [];
        $.each(rows, function (index, item) {
            ids.push(item.ID);
        });
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
        var rows = self.datagrid.datagrid('getSelections');
        if (!rows || rows.length == 0 || rows.length > 1) {
            $.messager.alert('提示', '请选中一条数据编辑！', 'warning');
            return null;
        }
        return rows[0];
    };

    //多选
    self.MultiRows = function () {
        var rows = self.datagrid.datagrid('getSelections');
        if (!rows || rows.length == 0) {
            $.messager.alert('提示', '至少选中一条数据！', 'warning');
            return null;
        }
        return rows;
    }

    //检索,{}各式
    self.search = function (condition) {
        self.datagrid.datagrid('load', condition);
    };

    //打开树窗口
    self.opentree = function (tree, treeDiv, onlyLeafCheck, url) {
        var row = self.SingleRow();
        if (row == null) return;

        treeDiv.show();
        tree.tree({
            url: url + "&&data=" + row.ID,
            checkbox: true,
            animate: true,
            onlyLeafCheck: onlyLeafCheck,
            lines: true
        });
        treeDiv.window({}).window('open');
    };
    //保存树选择
    self.savetree = function (tree, treeDiv, url) {
        //选择的节点
        var nodes = tree.tree('getChecked');
        var ids = [];
        for (var i = 0; i < nodes.length; i++) {
            ids.push(nodes[i].id);
        }
        //选择的记录
        var row = self.SingleRow();

        var obj = { Ids: ids, ID: row.ID };
        var data = { Data: JSON.stringify(obj) };
        $.ajax({
            url: url,
            type: "POST",
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(data),
            success: function (response) {
                $.messager.progress('close');
                treeDiv.window("close");
            }
        });
    };
};

var fileview = $.extend({}, $.fn.datagrid.defaults.view, {
    render: function (target, container, frozen) {
        var opts = $.data(target, 'datagrid').options;
        var rows = $.data(target, 'datagrid').data.rows;
        var fields = $(target).datagrid('getColumnFields', frozen);
        var table = [];
        table.push('<ul style="padding:10px;margin:0px;list-style:none; width:1000px; height:650px;">');
        for (var i = 0; i < rows.length; i++) {
            table.push(this.renderRow.call(this, target, i, rows[i]));
        }
        table.push('<ul>');
        $(container).prev().remove();
        $(container).html(table.join(''));
    },
    renderRow: function (target, rowIndex, rowData) {
        var opts = $.data(target, 'datagrid').options;
        var col = $(target).datagrid('getColumnOption', opts.textField);
        var td = [];
        td.push('<li class="head" style="float:left;width:135px; height:175px; margin:10px;"  >');
        td.push('<img src="' + rowData.HeadImage + '&ran=' + Math.random() + '" width="130" height="170"  refID="'
            + rowData.ID + '" onclick="vm.selectSingle(this,' + rowData.ID + ')"/>');
        td.push('<div class="divOperate">');
        td.push('<div class="down">');
        td.push('<div class="operate">');
        td.push('<a onclick="vm.pass(' + rowData.ID + ',\'' + rowData.Identification + '\')">审核通过</a>');
        td.push('<a onclick="vm.reject(' + rowData.ID + ',\'' + rowData.Identification + '\')">拒绝通过</a>');
        td.push('</div>');
        td.push('</div>');
        td.push('</div>');
        td.push('</li>');
        return td.join('');
    }
});


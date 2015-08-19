var viewModel = function () {
    var self = this;
    //初始化函数
    self.init = function () {

    };
    
    self.save=function() {
        var json = $("#dg").propertygrid("getData");
        $.messager.progress({});
        API.Request("SysSettingSave", json.rows, function() {
            $.messager.progress('close');
        });
    }

};

var vm = new viewModel();
$(function () {
    vm.init();
    $('#loading-mask').fadeOut();
});


var viewModel = function () {
    var self = this;

    //初始化函数
    self.init = function () {
        $("#dlg").show();
        $("#dlg").window({}).window('open');
    };

    //登录
    self.login = function () {
        $("#tip").text("");
        $.messager.progress({});
        $("#form1").form('submit', {
            onSubmit: function () {
                var valid = $(this).form('validate');
                if (!valid) {
                    $.messager.progress('close');
                }

                return valid;
            },
            success: function (response) {
                $.messager.progress('close');
                var jsonData = JSON.parse(response);
                if (jsonData.state) {
                    $.cookie('token', jsonData.token, { path: '/' });
                    window.location.href = "/System/home/index";
                }
                else {
                    $("#tip").text("账号或密码错误");
                }
            }
        });
    };
};

var vm = new viewModel();
$(function () {
    vm.init();
    $('#loading-mask').fadeOut();
})
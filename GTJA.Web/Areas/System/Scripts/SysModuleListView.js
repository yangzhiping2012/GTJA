var viewModel = function () {
    var self = this;

    //初始化函数
    self.init = function () {

    };

    //刷新
    self.reload = function () {
        $("#dg").treegrid("load");
    };

};

var vm = new viewModel();
$(function () {
    vm.init();
    $('#loading-mask').fadeOut();
})
;


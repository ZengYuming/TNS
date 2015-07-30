window.onload = function () {
    GetMenus();
    InitLeftMenu();
}
var _menus;


//从服务器拿菜单数据
function GetMenus() {
    $.ajax({
        type: "POST",
        cache: true,
        url: "/Shared/GetMenus",
        dataType: "json",
        async: false,
        success: function (data) {
            _menus = data;
        }
    });
}

//初始化左侧
function InitLeftMenu() {
    $(".easyui-accordion").empty();
    var menulist = "";
    for (var i = 0; i < _menus.length; i++) {
        menulist += '<div title="' + _menus[i].menuname + '"  icon="' + _menus[i].icon + '" style="overflow:auto;">';
        menulist += '<ul>';
        if (_menus[i].menus !== undefined) {
            for (var j = 0; j < _menus[i].menus.length; j++) {
                menulist += '<li><div><a href="javascript:;" target="mainFrame" url="' + _menus[i].menus[j].url + '"><span class="icon ' + _menus[i].menus[j].icon + '" ></span>' + _menus[i].menus[j].menuname + '</a></div></li> ';
            }
        }

        menulist += '</ul></div>';
    }
    $(".easyui-accordion").append(menulist);
    $('.easyui-accordion li a').click(function () {
        var tabTitle = $(this).text();
        var url = $(this).attr("url");
        addTab(tabTitle, url);
        $('.easyui-accordion li div').removeClass("selected");
        $(this).parent().addClass("selected");
    }).hover(function () {
        $(this).parent().addClass("hover");
    }, function () {
        $(this).parent().removeClass("hover");
    });

    $(".easyui-accordion").accordion();
}

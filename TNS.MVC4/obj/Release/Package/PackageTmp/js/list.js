// 全局变量
var grid;
var dlg_Edit;
var dlg_Edit_form;
var virpath = ""; //网站的虚拟目录 如：/ShopManager
var model;
var modelName;
var addUrl;
var editUrl;
var delUrl;
var categorys;
var title;

$(function () {
    $.fn.datebox.defaults.formatter = function (date) {
        var y = date.getFullYear();
        var m = date.getMonth() + 1;
        var d = date.getDate();
        return y + '-' + m + '-' + d;
    };
    //编辑
    dlg_Edit = $('#dlg_Edit').dialog({
        closed: true,
        modal: true,
        onClose: function () {
            $('.validatebox-tip').remove();
            $('#dlg_Edit').dialog('close');
        }
    });
    dlg_Edit_form = dlg_Edit.find('form');
    $("#btnSave").click(function () {
        var token = $("body>input").val();
        $("#hdToken").val(token);
        saveData();
    });
    $("#btnClose").click(function () {
        $('.validatebox-tip').remove();
        $('#dlg_Edit').dialog('close');
    });
    //$(body).layout();
});

function createColumnMenu() {
    var tmenu = $('<div id="tmenu" style="width:100px;"></div>').appendTo('body');
    var fields = grid.datagrid('getColumnFields');
    for (var i = 0; i < fields.length; i++) {
        $('<div iconCls="icon-ok"/>').html(fields[i]).appendTo(tmenu);
    }
    tmenu.menu({
        onClick: function (item) {
            if (item.iconCls == 'icon-ok') {
                grid.datagrid('hideColumn', item.text);
                tmenu.menu('setIcon', {
                    target: item.target,
                    iconCls: 'icon-empty'
                });
            } else {
                grid.datagrid('showColumn', item.text);
                tmenu.menu('setIcon', {
                    target: item.target,
                    iconCls: 'icon-ok'
                });
            }
        }
    });
}
function getSelectedArr() {
    var ids = [];
    var rows = grid.datagrid('getSelections');
    var id;
    for (var i = 0; i < rows.length; i++) {
        id = eval("rows[i]." + model + "Id");
        ids.push(id);
    }
    return ids;
}
function getSelectedID() {
    var ids = getSelectedArr();
    return ids.join(',');
}
function arr2str(arr) {
    return arr.join(',');
}

function add() {
    dlg_Edit_form.form('clear');
    initEditDialog("");
    dlg_Edit.dialog('open');
    dlg_Edit.dialog('setTitle', 'Add-' + modelName);
    //$('#Enable').combobox('setValue', true); //默认设置开启
    dlg_Edit_form.url = virpath + addUrl;
    //Msgalert("提示", '成功调用', "info");
}
function edit() {
    var rows = grid.datagrid('getSelections');
    var num = rows.length;
    var name;
    if (num == 0) {
        Msgshow('Please select an item!');
        return;
    }
    else if (num > 1) {
        $.messager.alert('Tips', 'Just select one item to edit!', 'info');
        return;
    }
    else {
        dlg_Edit_form.form('clear');
        dlg_Edit_form.url = virpath + editUrl;
        initEditDialog(rows[0]);
        dlg_Edit.dialog('open');
        name = eval('rows[0].' + title);
        dlg_Edit.dialog('setTitle', 'Edit:' + name);
        dlg_Edit_form.form('load', rows[0]); //加载到表单的控件上 
    }
}
function del() {
    var arr = getSelectedArr();
    if (arr.length > 0) {
        $.messager.confirm('Tips', 'Are you sure to delete this item?', function (data) {
            if (data) {
                $.ajax({
                    url: virpath + delUrl + '?ids=' + arr2str(arr),
                    type: 'post',
                    error: function () {
                        Msgalert('Error', 'Delete failed!', 'error');
                        grid.datagrid('clearSelections');
                    },
                    success: function (re) {
                        var data = eval('(' + re + ')');
                        if (data.success) {
                            Msgfade(arr.length + "items" + data.msg); //提示消息
                            grid.datagrid('reload');
                            grid.datagrid('clearSelections'); //清除所有选中的元素
                        } else {
                            Msgalert('Error', data.msg, 'error');
                        }
                    }
                });
            }
        });
    } else {
        Msgshow('Please to selete an item to delete.');
    }
}
function saveData() {
    dlg_Edit_form.form('submit', {
        url: dlg_Edit_form.url,
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: successCallback
    });
}

function getCategoryText(type, val) {
    if (typeof (categorys) == "undefined" || categorys == "") {
        return "";
    }
    if (val == "0")
        return "";
    var types = eval(categorys);
    for (var i = 0; i < types.length; i++) {
        if (types[i].PCode == type && types[i].Code == val) {
            return types[i].Text;
        }
    }
    return val;
}

function addAllOpt(type) {
    var opt = '{"PCode":"' + type + '","Code":"","Text":"All","OrderNo":0}';
    if (typeof (categorys) == "undefined" || categorys == "") {
        return eval('[' + opt + ']');
    }
    else {
        var array = new Array();
        var newcategorys = '[' + opt + ',' + categorys.substr(1);
        var types = eval(newcategorys);
        for (var i = 0; i < types.length; i++) {
            if (types[i].PCode == type) {
                array.push(types[i]);
            }
        }
        return array;
    }
}
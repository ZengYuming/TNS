function dateformatter(date) {
    var y = date.getFullYear();
    var m = date.getMonth() + 1;
    var d = date.getDate();
    return y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
}
function dateparser(s) {
    if (!s) return new Date();
    var ss = s.split('-');
    var y = parseInt(ss[0], 10);
    var m = parseInt(ss[1], 10);
    var d = parseInt(ss[2], 10);
    if (!isNaN(y) && !isNaN(m) && !isNaN(d)) {
        return new Date(y, m - 1, d);
    } else {
        return new Date();
    }
}

function Msgshow(msg) {
    $.messager.show({
        title: 'Tips',
        msg: msg,
        showType: 'show'
    });
}
function Msgslide(msg) {
    $.messager.show({
        title: 'Tips',
        msg: msg,
        timeout: 3000,
        showType: 'slide'
    });
}
function Msgfade(msg) {
    $.messager.show({
        title: 'Tips',
        msg: msg,
        timeout: 3000,
        showType: 'fade'
    });
}
//弹出信息窗口 title:标题 msgString:提示信息 msgType:信息类型 [error,info,question,warning]
function Msgalert(title, msgString, msgType) {
    $.messager.alert(title, msgString, msgType);
}

///当提交信息的触发
var successCallback = function (msg) {
    //result为请求处理后的返回值   
    //var result = jQuery.parseJSON(msg);
    var result = eval('(' + msg + ')');
    if (result.success) {
        $.messager.show({
            title: 'Success',
            msg: result.msg,
            timeout: 2000,
            showType: 'fade'
        });
        grid.datagrid('reload'); //grid变量要与其他文件中的一致
        dlg_Edit.dialog('close'); //dlg_Edit与其他文件中的一致  才能公共调用 
    } else {
        $.messager.show({
            title: 'Error',
            msg: result.msg
        });
    }
};
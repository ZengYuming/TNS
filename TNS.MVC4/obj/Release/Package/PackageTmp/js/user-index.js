var grid;
model = "Person";
modelName = "用户";

var firstName = "";
var sDate = "";
var eDate = "";

$(function () {
    grid = $('#content').datagrid({
        title: '用户列表',
        iconCls: '',
        methord: 'post',
        url: '/User/GetUsers',
        queryParams: { StarTime: sDate, EndTime: eDate },
        sortName: 'firstName',
        sortOrder: 'desc',
        idField: 'personId',
        pageSize: 20000000,
        striped: true, //奇偶行是否区分
        frozenColumns: [[
            { field: 'ck', checkbox: true }
        ]],
        columns: [[
            { field: 'personId', title: '用户ID', hidden: true },
            { field: 'firstName', title: '姓氏', width: 50, sortable: true },
            { field: 'secondName', title: '名字', width: 60, sortable: true },
            { field: 'comments', title: '备注', width: 30, sortable: true }
        ]],
        fit: true,
        pagination: false,
        rownumbers: true,
        fitColumns: true,
        singleSelect: true
    });
});

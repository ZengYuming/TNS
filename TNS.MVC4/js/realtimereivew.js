var grid;
model = "RealtimeReview";
modelName = "Realtime Review";
title = "id";
var hotelId = "6606";
var itemsCount = "100";
var checkin = "";
var checkout = "";
addUrl = "/RealtimeReview/Create";

$(function () {
    grid = $('#content').datagrid({
        title: 'Realtime Review List',
        iconCls: '',
        methord: 'post',
        url: '/RealtimeReview/GetRealtimeReviews',
        queryParams: { hotelId: hotelId, itemsCount: itemsCount },
        sortName: 'endDate',
        sortOrder: 'desc',
        idField: 'id',
        pageSize: 20000000,
        striped: true, //奇偶行是否区分    
        columns: [[{ title: 'Date', colspan: 2 }, { title: 'First', colspan: 3 }, { title: 'Second', colspan: 3 }, { title: 'Third', colspan: 3 }, { title: 'Misc', colspan: 6 }],
            [
                    { field: 'id', title: 'id', hidden: true }, //"55963a2cc6232708fc9c1a9e",
                    { field: 'CheckInDate', title: 'Check-In', width: 80, sortable: false, formatter: function (value, row, index) { return dateformatter(dateparser(value)); } },// "2015-07-01T00:00:00Z",
                    { field: 'CheckOutDate', title: 'Check-Out', width: 80, sortable: false, formatter: function (value, row, index) { return dateformatter(dateparser(value)); } },// "2085-11-15T00:00:00Z",
                    { field: 'FirstAnswer', title: 'Answer', width: 50, sortable: false, formatter: formatterOfAnswer },
                    { field: 'TagsOfFirstAnswer', title: 'Tags', width: 80, sortable: false, formatter: formatterOfTags },
                    { field: 'CustomTagsOfFirstAnswer', title: 'Custom Tags', width: 80, sortable: false },//"2015-07-03T08:16:27Z",
                    { field: 'SecondAnswer', title: 'Answer', width: 50, sortable: false, formatter: formatterOfAnswer },
                    { field: 'TagsOfSecondAnswer', title: 'Tags', width: 80, sortable: false, formatter: formatterOfTags },
                    { field: 'CustomTagsOfSecondAnswer', title: 'Custom Tags', width: 80, sortable: false },
                    { field: 'ThirdAnswer', title: 'Answer', width: 50, sortable: false, formatter: formatterOfAnswer },
                    { field: 'TagsOfThirdAnswer', title: 'Tags', width: 80, sortable: false, formatter: formatterOfTags },
                    { field: 'CustomTagsOfThirdAnswer', title: 'Custom Tags', width: 80, sortable: false },
                    { field: 'HotelId', title: 'Hotel Id', width: 50, sortable: false },// "6606",
                    { field: 'Language', title: 'Language', width: 80, sortable: false },// "en_US",
                    { field: 'BookingId', title: 'Booking ID', width: 50, sortable: false },//bookingId
                    { field: 'Comment', title: 'Comment', width: 150, sortable: false },// "Tony001,  itineraryID:11564393412,  checkin:2015-07-01,  checkout:2085-11-15,  timeofCommentCreation:7/3/2015 1:16:24 AM,  langugeId:1033,  siteId:1,  tagsOfFirstAnswer:1,2,3,  tagsOfSecondAnswer:3,4,  tagsOfThirdAnswer:5,8,13",
            ]
        ],
        fit: true,
        pagination: false,
        rownumbers: true,
        fitColumns: true,
        singleSelect: true,
        toolbar: [{
            text: 'Add',
            iconCls: 'icon-add',
            handler: add
        }],
        onLoadSuccess: function () {
            var lastTd = $(".datagrid-toolbar td").last();
            var tdSeparator = '<td><div class="datagrid-btn-separator"></div></td>';
            if (lastTd.attr("id") != "tbSearch") {
                var td = '<td id="tbSearch">';
                //hotel id
                td += '<span style="padding:5px; font:12px/1.5 tahoma">Hotel ID:</span>' +
                    '<span class="combo" style="width: 80px; height: 20px;"><input id="txtHotelId" type="text" class="combo-text" value=""></span>&nbsp;';
                //item count
                td += '<span style="padding:5px; font:12px/1.5 tahoma">Item Count:</span>' +
                  '<span class="combo" style="width: 80px; height: 20px;"><input id="txtItemsCount" type="text" class="combo-text" value=""></span>&nbsp;';
                //check-in date
                td += '<span style="padding:5px; font:12px/1.5 tahoma">Check-in Date:</span>' +
                 '<input id="txtCheckIn" style="width:100px">&nbsp;';
                //check-out date
                td += '<span style="padding:5px; font:12px/1.5 tahoma">Check-out Date:</span>' +
                 '<input id="txtCheckOut"  style="width:100px">&nbsp;';
                //search button
                td += '<a href="javascript:void(0)" class="l-btn l-btn-plain" id="aSearch" onclick="doSearch()"><span class="l-btn-left">' +
                    '<span class="l-btn-text icon-search l-btn-icon-left">Search</span></span></a></td>';
                lastTd.parent().append(tdSeparator + td);
            }
            $("#txtCheckIn").datebox({
                formatter: dateformatter,
                onSelect: function (date) {
                    $(this).val(date);
                }
            });
            $("#txtCheckOut").datebox({
                formatter: dateformatter,
                onSelect: function (date) {
                    $(this).val(date);
                }
            });
            $("#txtCheckIn").datebox('setValue', checkin);
            $("#txtCheckOut").datebox('setValue', checkout);
            $("#txtHotelId").val(hotelId);
            $("#txtItemsCount").val(itemsCount);
        }
    });
});
function formatterOfAnswer(value, row, index) {
    if (value == "Sad") {
        return "<div class='sad'></div>";
    }
    if (value == "Happy") {
        return "<div class='happy'></div>";
    }
    if (value == "None") {
        return "<div class='none'></div>";
    }
}

function formatterOfTags(value, row, index) {
    var html = "";
    if (value != null) {
        var tags = value.split(',');
        for (var i = 0; i < tags.length; i++) {
            if (row.FirstAnswer == "Happy") {
                html += "<span class='happytags'>" + tags[i] + "</span>";
            }
            else {
                html += "<span class='sadtags'>" + tags[i] + "</span>";
            }
        }
    }
    return html;
}

function doSearch() {
    hotelId = $("#txtHotelId").val();
    itemsCount = $("#txtItemsCount").val();
    checkin = $("#txtCheckIn").datebox('getValue');
    checkout = $("#txtCheckOut").datebox('getValue');
    grid.datagrid({
        url: '/RealtimeReview/GetRealtimeReviews',
        queryParams: { hotelId: hotelId, itemsCount: itemsCount, checkin: checkin, checkout: checkout },
        pageNumber: 1
    });
}



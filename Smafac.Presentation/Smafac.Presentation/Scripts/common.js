$(document).ready(function () {
    $(document).on('click', '.btn-postid', function () {
        var link = $(this);
        var action = link.attr("data-action");
        var identity = link.attr("data-identity");
        var data = {
            id: identity
        };

        $.ajax({
            type: "post",
            url: action,
            data: data,
            dataType: "json",
            success: function (data) {
                ajaxSuccess(data, function (data) {
                    window.location.reload();
                })
            },
            error: function (data) { }
        });
    });
});


$(document).ready(function () {
    $(document).on('click', '.btn-view', function () {
        var btn = $(this);
        btnviewCallback(btn)
    });
});

function btnviewCallback(btn)
{
    var view = btn.attr("data-view");
    $.ajax({
        type: "get",
        url: view,
        dataType: "html",
        success: function (data) {
            var container = btn.attr("data-view");
            if (container == '' || container == undefined) {
                container = 'view-container';
            }
            $('#view-container').html(data);
        },
        error: function (data) {
            alert('页面错误');
        }
    });
}

$(document).ready(function () {
    $(document).on('click', '.btn-submit', function () {
        var button = $(this);
        var url = button.attr('data-url');
        var formid = button.attr("data-form");
        if (formid == "undefined" || formid == null) {
            formid = "form-submit";
        }
        var form = $('#' + formid);
        var data = form.serializeArray();

        $.ajax({
            type: "post",
            url: url,
            data: data,
            dataType: "json",
            success: function (data) {
                ajaxSuccess(data, function () {
                    window.location.reload();
                });
            },
            error: function (data) { }
        });
    });
});

function ajaxSuccess(data, callback) {
    if (data.Code == 0) {
        callback(data.Data);
    }
    else {
        alert(data.Message)
    }
}

$(function () {
    var paginator = $('#paginator-wrapper');
    if (paginator.length == 0) {
        return;
    }
    getTotalPage();
})

$(function () {
    $('.pageContainer').each(function () {
        var container = $(this);
        var action = container.attr('data-view');
        $.ajax({
            type: "get",
            url: action,
            dataType: "html",
            success: function (data) {
                container.html(data);
            }
        });
    });
})


$(document).ready(function () {
    $(document).on('click', '.btn-page', function () {
        getTotalPage();
    });
});

$(function () {
    $('.form_date').datetimepicker({
        language: 'zh-CN',
        weekStart: 1,
        todayBtn: 1,
        autoclose: 1,
        todayHighlight: 1,
        startView: 2,
        minView: 2,
        forceParse: 0
    });
})


function getPageHtml(page) {
    var form = $('#form-search');
    var action = form.attr('action');
    var data = form.serializeArray();
    data.push({ pageindex: page });

    $.ajax({
        type: "get",
        url: action,
        data: data,
        dataType: "html",
        success: function (data) {
            $('#table-container').html(data);
        }
    });
}

function getTotalPage() {
    var form = $('#form-search');
    var action = form.attr('action');
    var url = action.replace('View', '');
    var data = form.serializeArray();
    data.push({ pageindex: 0 });
    $.ajax({
        type: "post",
        url: url,
        data: data,
        dataType: "json",
        success: function (data) {
            var totalpage = data.Data.TotalPage;
            if (totalpage == 0) {
                totalpage = 1;
            }
            $('#paginator-wrapper').jqPaginator({
                totalPages: totalpage,
                visiblePages: 10,
                currentPage: 1,
                onPageChange: function (num, type) {
                    getPageHtml(num);
                }
            });
        }
    });
}
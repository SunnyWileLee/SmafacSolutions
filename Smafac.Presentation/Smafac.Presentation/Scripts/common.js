$(document).ready(function () {
    $(document).on('click', '.btn-postid', function () {
        var link = $(this);
        var action = link.attr("data-url");
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

function btnviewCallback(btn) {
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
        console.log(formid);
        var form = $('#' + formid);
        var data = form.serializeArray();
        console.log(data);
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

function ajaxSuccess(data, callback, ignore) {
    if (data.Code == 0) {
        if (ignore != true) {
            alert('操作成功')
        }
        callback(data.Data);
    }
    else {
        alert(data.Message)
    }
}

$(function () {
    var paginator = $('#pagination-container');
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


$(document).ready(function () {
    $(function () {
        $('.date-select').datetimepicker({
            format: 'YYYY/MM/DD',
            locale: 'zh-cn'
        });
    });
});

function getPageHtml(page) {
    if (page > 0) {
        page = page - 1;
    }
    var form = $('#form-search');
    var action = form.attr('data-page');
    var data = { pageindex: page };
    $('.input-search').each(function (index) {
        var input = $(this);
        var name = input.attr('name');
        var value = input.val();
        data[name] = value;
    })

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
    var action = form.attr('data-page');
    var url = action.replace('View', '');

    var data = { pageindex: 0 };
    $('.input-search').each(function (index) {
        var input = $(this);
        var name = input.attr('name');
        var value = input.val();
        data[name] = value;
    })

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
            $('#pagination-container').jqPaginator({
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
$(document).ready(function () {
    $.ajax({
        type: "post",
        url: "/Statistics/ajax_GetStatistic",
        data: {  },
        dataType: "json",
        success: function (zjson) {
            $("#lbReport").html(zjson.Reports);
            $("#lbDispatch").html(zjson.Dispatch);
            $("#lbExec").html(zjson.Exec);
            $("#lbComplete").html(zjson.Complete);           
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });

    $(".reportlist").click(function () {
        parent.AddTabNav("ReportList1", "待审核", "/Statistics/ReportList?type=0");
    });
    $(".dispatchlist").click(function () {
        parent.AddTabNav("ReportList2", "待派工", "/Statistics/ReportList?type=1");
    });
    $(".execlist").click(function () {
        parent.AddTabNav("ReportList3", "待执行", "/Statistics/ReportList?type=2");
    });
    $(".completelist").click(function () {
        parent.AddTabNav("ReportList4", "待完结", "/Statistics/ReportList?type=3");
    });


    $.ajax({
        type: "post",
        url: "/Statistics/ajax_InvalidTime",
        data: {},
        dataType: "json",
        success: function (zjson) {
            $("#invalidTime").html(zjson.data );
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });


    $("#faultRate_More").click(function () {
        parent.AddTabNav("FaultRate", "故障排名", "/Statistics/FaultRate?type=1");
    });
    $("#faultNumber_More").click(function () {
        parent.AddTabNav("FaultNumber", "故障数", "/Statistics/FaultNumber?type=1");
    });
    $("#invalidTime_More").click(function () {
        parent.AddTabNav("InvalidTime", "失效时间", "/Statistics/InvalidTime");
    });
})
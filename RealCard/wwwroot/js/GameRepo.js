﻿function GetDeckById(id) {
    $.ajax({
            url: "/AjaxDeck/Detail?id=" + id,
            type: "GET",
            dataType: "json"
        })
        .done(function (data) {
            BuildDeck(data);
        })
        .fail(function() {
            console.log("error");
        });
}
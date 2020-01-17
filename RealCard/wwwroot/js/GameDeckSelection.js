$(".deckSelector").on("click", function() {
    var dckId = $(this).data("deck-id");
    $("#gameContainer").load("/Game/GetGameMainView?id=" + dckId);
});

$(".getBack").click(function () {
    $.ajax({
            url: "/Game/Index",
            type: "GET",
            dataType: "html"
        })
        .done(function (data) {
            $("#gameContainer").html(data);
        });
});
var deck;
var currentDeckIds = [];

function BuildDeck(data) {
    deck = JSON.parse(data);
    deck.forEach(function (d) {
        currentDeckIds.push(d.id);
        $(".chosenCards").append('<div class="chosenCard" data-card-id=' + d.id + '>' + d.name + '</div>');
    });
}

$(".cardContainer").click(function () {
    var cardId = $(this).data("card-id");
    var cardName = $(this).data("card-name");

    if (currentDeckIds.indexOf(cardId) === -1 && currentDeckIds.length < 15) {
        currentDeckIds.push(cardId);
        $(".chosenCards").append('<div class="chosenCard" data-card-id=' + cardId + ">" + cardName + "</div>");
    }
    else if (currentDeckIds.indexOf(cardId) !== -1) {
        alert("Error: already in deck");
    }
    else if (currentDeckIds.length >= 15) {
        alert("Error: Deck can only contain 15 cards");
    }
});

$(".saveDeck").click(function () {
    if (currentDeckIds.length < 15) {
        alert("Error: 15 cards are required in your deck");
    } else {
        var jsonData = {
            cardIds: currentDeckIds,
            id: $("#deckDetailPage").data("deck-id"),
            deckName: $(".deckName").val()
        };
        $.ajax({
            url: "/AjaxDeck/Save",
            contentType: "application/json; charset=utf-8",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            type: "POST",
            dataType: "json",
            data: JSON.stringify(jsonData)
        })
            .done(function () {
                currentDeckIds = [];
                $(".goBack").trigger("click");
            })
            .fail(function () {
                console.log("fail");
            });
    }
});

$(document).on("click",
    ".chosenCard",
    function () {
        var cardId = $(this).data("card-id");
        var cardIndex = currentDeckIds.indexOf(cardId);
        currentDeckIds.splice(cardIndex, 1);
        $(this).remove();
    });

$(".goBack").on("click", (function () {
    $.ajax({
        url: "/Game/GetDeckIndexView",
        type: "GET",
        dataType: "html"
    })
        .done(function (data) {
            $("#gameContainer").html(data);
        });
}));
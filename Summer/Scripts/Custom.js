function Confirming(x,y) {
    $(x).on('click', function() {

        bootbox.confirm({
            size: "small",
            message: "Are you Certain Cus this cannot be Undone?",
            callback: function(result) {
                if (result)
                    $(y).submit();
            }
        });
    });
};
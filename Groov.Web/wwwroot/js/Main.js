function MakeAjaxCall(options) {
    return $.ajax({
        type: options.type,
        url: options.url,
        async: options.async,
        data: options.data,
        dataType: options.dataType,
        contentType: options.contentType,
        succes: function (response) {
            options.callbackOk(response);
        },
        error: function (ex) {
            options.callbackError(response);
        }
    });
}
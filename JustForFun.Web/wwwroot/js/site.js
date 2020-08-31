// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function msgBox(content, title = '提示') {
    layui.use('layer', function () {
        let layer = layui.layer;

        layer.open({
            title: title,
            content: content
        });
    });
}

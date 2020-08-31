layui.use('table', function () {
    let table = layui.table;

    table.render({
        elem: '#musicList',
        url: '/NeteaseMusicShuffle/MusicList/',
        cellMinWidth: 80, //全局定义常规单元格的最小宽度，layui 2.2.1 新增
        cols: [[
            {field: 'id', title: 'ID', width: 70, sort: true},
            {field: 'title', title: '歌曲名称'} //width 支持：数字、百分比和不填写。你还可以通过 minWidth 参数局部定义当前单元格的最小宽度，layui 2.2.1 新增
        ]]
    });
});
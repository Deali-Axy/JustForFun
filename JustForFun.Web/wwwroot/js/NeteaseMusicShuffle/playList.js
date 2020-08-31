let currentTurnTable
let currentPlayTable

layui.use('table', function () {
    currentTurnTable = layui.table
    currentPlayTable = layui.table

    currentTurnTable.render({
        id: 'currentTurn',
        elem: '#currentTurn',
        cellMinWidth: 80, //全局定义常规单元格的最小宽度，layui 2.2.1 新增
        cols: [[
            {field: 'title', title: '歌曲名称'},
            {field: 'playedTimes', title: '播放次数', width: 100, sort: true},
        ]],
        data: [{
            title: '点击「下一轮」按钮开始播放'
        }]
    })

    currentPlayTable.render({
        id: 'currentPlay',
        elem: '#currentPlay',
        url: '/NeteaseMusicShuffle/CurrentPlay',
        cellMinWidth: 80, //全局定义常规单元格的最小宽度，layui 2.2.1 新增
        cols: [[
            {field: 'title', title: '歌曲名称'},
            {field: 'playedTimes', title: '播放次数', width: 100, sort: true},
        ]],
    })
});


$('#next-turn').on('click', function (e) {
    layui.use('layer', function () {
        $.get('/NeteaseMusicShuffle/NextTurn', function (resJson) {
            console.log(resJson.data)

            currentTurnTable.reload('currentTurn', {
                data: resJson.data.list
            })

            $('#current-turn').text(resJson.data.currentTurn)
        })

        currentPlayTable.reload('currentPlay')
    });
})
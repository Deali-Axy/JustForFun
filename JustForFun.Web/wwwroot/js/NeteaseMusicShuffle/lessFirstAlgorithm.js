let currentTurnTable
let currentPlayTable
let chart = echarts.init(document.querySelector('#chart'))

layui.use('table', function () {
    currentTurnTable = layui.table
    currentPlayTable = layui.table

    currentTurnTable.render({
        id: 'currentTurn',
        loading: false,
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
        loading: false,
        elem: '#currentPlay',
        url: '/NeteaseMusicShuffle/LessFirstCurrentPlay',
        cellMinWidth: 80, //全局定义常规单元格的最小宽度，layui 2.2.1 新增
        cols: [[
            {field: 'title', title: '歌曲名称'},
            {field: 'playedTimes', title: '播放次数', width: 100, sort: true},
        ]],
    })
});


$('#next-turn').on('click', function (e) {
    layui.use('layer', function () {
        $.get('/NeteaseMusicShuffle/LessFirstNextTurn', function (resJson) {
            console.log(resJson.data)

            currentTurnTable.reload('currentTurn', {
                data: resJson.data.list
            })

            $('#current-turn').text(resJson.data.currentTurn)
            $('#total-play').text(resJson.data.currentTurn * 10)
        })

        currentPlayTable.reload('currentPlay')

        chartReload()
    })
})

function updateChart(titleList, playedTimesList) {
    chart.setOption({
        color: ['#3398DB'],
        tooltip: {
            trigger: 'axis',
            axisPointer: {            // 坐标轴指示器，坐标轴触发有效
                type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
            }
        },
        grid: {
            left: '3%',
            right: '4%',
            bottom: '3%',
            containLabel: true
        },
        xAxis: [
            {
                type: 'category',
                data: titleList,
                axisTick: {
                    alignWithLabel: true
                }
            }
        ],
        yAxis: [
            {
                type: 'value'
            }
        ],
        series: [
            {
                name: '直接访问',
                type: 'bar',
                barWidth: '40%',
                data: playedTimesList
            }
        ]
    })
}

function chartReload() {
    // chart.showLoading()

    $.get('/NeteaseMusicShuffle/LessFirstCurrentPlay', function (resJson) {
        // chart.hideLoading()

        updateChart(
            resJson.data.map(item => item.title),
            resJson.data.map(item => item.playedTimes)
        )
    })
}


chartReload()

$.get('/NeteaseMusicShuffle/LessFirstCurrentTurn', function (resJson) {
    console.log(resJson.data)
    $('#current-turn').text(resJson.data.currentTurn)
    $('#total-play').text(resJson.data.currentTurn * resJson.data.everyTurnMusicCount)
})
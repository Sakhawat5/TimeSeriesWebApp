
import { Component, OnInit } from '@angular/core';
import * as CanvasJS from '../canvasjs.min';
//var CanvasJS = require('./canvasjs.min');

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  ngOnInit() {
    let dataPoints = [
      //{ x: 1501048673000, y: 35.939 },
      //{ x: 1501052273000, y: 40.896 },
      //{ x: 1501055873000, y: 56.625 },
      //{ x: 1501059473000, y: 26.003 },
      //{ x: 1501063073000, y: 20.376 },
      //{ x: 1501066673000, y: 19.774 },
      //{ x: 1501070273000, y: 23.508 },
      //{ x: 1501073873000, y: 18.577 },
      //{ x: 1501077473000, y: 15.918 },
      //{ x: 1501081073000, y: 32.65 }, // Null Data
      //{ x: 1501084673000, y: 10.314 },
      //{ x: 1501088273000, y: 10.574 },
      //{ x: 1501091873000, y: 14.422 },
      //{ x: 1501095473000, y: 18.576 },
      //{ x: 1501099073000, y: 22.342 },
      //{ x: 1501102673000, y: 22.836 },
      //{ x: 1501106273000, y: 23.220 },
      //{ x: 1501109873000, y: 23.594 },
      //{ x: 1501113473000, y: 24.596 },
      //{ x: 1501117073000, y: 31.947 },
      //{ x: 1501120673000, y: 31.142 }
    ];
    let y = 0;
    for (var i = 0; i < 10000; i++) {
      y += Math.round(10 + Math.random() * (-10 - 10));
      dataPoints.push({ y: y });
    }
    let chart = new CanvasJS.Chart("chartContainer", {
      zoomEnabled: true,
      animationEnabled: true,
      exportEnabled: true,
      title: {
        text: "Timeseries Data"
      },
      //subtitles: [{
      //  text: "Try Zooming and Panning"
      //}],
      axisX: {
        title: "Time",
        //gridThickness: 1,
        interval: 1,
        intervalType: "hour",
      },
      axisY: {
        tickLength: 0,
        title: "Value",
      },
      data: [
        {
          type: "line",
          name: "CPU Utilization",
          connectNullData: true,
          //nullDataLineDashType: "solid",
          xValueType: "dateTime",
          xValueFormatString: "HH:mm 'hrs' <br/> DD/MM/YYYY (DDD)",
          yValueFormatString: "#,##0.##",

          dataPoints: dataPoints
        }]
    });

    chart.render();
  }
}

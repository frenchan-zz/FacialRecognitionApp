import { Component, OnInit } from '@angular/core';
import 'tracking/build/tracking.js';
import 'tracking/build/data/face.js';
import { FaceService } from '../face.service';
import { FaceApi, Face } from '../face';


@Component({
  selector: 'app-face-detection',
  templateUrl: './face.detection.component.html',
  styleUrls: ['./face.detection.component.css']
})
export class FaceDetectionComponent implements OnInit {
  tracker: any;
  task: any;
  dataUri: string;
  faceApi: FaceApi = {
    data: ''
  };
  face: Face;

  constructor(private faceService: FaceService) { }

  ngOnInit() {
    this.initTracker();
  }

  getData(): void {
      this.faceApi.data = this.dataUri.replace(/^data:image\/(png|jpg|jpeg);base64,/, "");
      this.faceService.getData(JSON.stringify(this.faceApi));
      this.face = this.faceService.face;
  }

  initTracker(): void {
    try {
      const global = <any>window;
      this.tracker = new global.tracking.ObjectTracker('face');
      this.task = global.tracking.track('#video', this.tracker, { camera: true });

      this.tracker.on('track', (event) => {
        const { data } = event;
        this.tryToDetectFace(data);
      });
      this.tracker.setInitialScale(4);
      this.tracker.setStepSize(2);
      this.tracker.setEdgesDensity(0.1);

    } catch (e) {
      console.error(e);
    }
  }

  tryToDetectFace(trackedData: any): void {
    if (trackedData.length > 0) {
      const video = <HTMLVideoElement>document.getElementsByTagName('video')[0];
      const canvas = <HTMLCanvasElement>document.getElementsByTagName('canvas')[0];
      const context = canvas.getContext('2d');

      canvas.setAttribute('style', 'width: 320px; height: 240px');
      context.drawImage(video, 0, 0, 320, 240);
      this.dataUri = canvas.toDataURL('image/jpeg');

      trackedData.forEach((rect) => {
        const gradient = context.createLinearGradient(0, 0, 170, 0);
        gradient.addColorStop(0, 'magenta');
        gradient.addColorStop(0.5, 'blue');
        gradient.addColorStop(1.0, 'red');
        context.strokeStyle = gradient;
          context.strokeRect(rect.x, rect.y, rect.width, rect.height);
          context.font = '11px Helvetica';
          context.fillStyle = "#fff";
          context.fillText('x: ' + rect.x + 'px', rect.x + rect.width + 5, rect.y + 11);
          context.fillText('y: ' + rect.y + 'px', rect.x + rect.width + 5, rect.y + 22);
      });
    }
  }
}

import { Component, EventEmitter, Input, Output } from '@angular/core';
import { News } from 'src/app/models/news';

@Component({
  selector: 'app-delete-news',
  templateUrl: './delete-news.component.html',
  styleUrls: ['./delete-news.component.css']
})
export class DeleteNewsComponent {
  @Input()
  news: News = new News();
  @Output()
  restart = new EventEmitter<void>();
  constructor(){ }

  ngOnInit(): void {
  }
  passBack(choice:any) {
    this.restart.emit(choice);
  }
  yes(){
    this.passBack(true);
  }
  no(){
    this.passBack(false);
  }
  /*initParameters(inputs: { news: News}, outputs: { restart: (...args: any[]) => any }) {
    for (let prop in inputs)
      this[prop:] = inputs[prop];
    for (let prop in outputs)
      (this[prop] as EventEmitter<any>).subscribe(outputs[prop]);
  }
    
  */
}

import { Component, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { News } from 'src/app/models/news';

@Component({
  selector: 'app-delete-news',
  templateUrl: './delete-news.component.html',
  styleUrls: ['./delete-news.component.css'],
})
export class DeleteNewsComponent {
  @Input() news: News;

  constructor(public activeModal: NgbActiveModal) {}

  confirmDelete(): void {
    
    this.activeModal.close('delete');
  }

  cancelDelete(): void {
    this.activeModal.dismiss('cancel');
  }
}
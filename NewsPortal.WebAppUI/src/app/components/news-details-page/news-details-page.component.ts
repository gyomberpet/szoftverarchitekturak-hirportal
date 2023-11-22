import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, NavigationExtras } from '@angular/router';
import { News } from 'src/app/models/news';
import { NewsService } from 'src/app/service/news.service';
import { DeleteNewsComponent } from '../delete-news/delete-news.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-news-details-page',
  templateUrl: './news-details-page.component.html',
  styleUrls: ['./news-details-page.component.css'],
})
export class NewsDetailsPageComponent implements OnInit {
  news: News = new News();
  randomNewsList: News[] = [];
  private reloadComponent: boolean = false; // Belső állapotváltozó
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private newsService: NewsService,
    private dialogRef: MatDialog,
    private modalService: NgbModal
    
  ) {}

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id')!;
    this.newsService.getNewsById(id).subscribe({
      next: (res: News) => {
        this.news = res;
        if (this.news.category?.name) {
          this.newsService.getRandomNewsByCategory(this.news.category.name, 3).subscribe({
            next: (res: News[]) => {
              this.randomNewsList = res.filter(x => x.id !== this.news.id);
            },
            error: (err) => console.error(err),
          });
        } else {
          console.error('Category name is undefined');
        }
      },
      error: (err) => console.error(err),
    });
    // Újratöltés ellenőrzése
  }
  navigateToNews(newsId?: number): void {
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate(['news', newsId]);
    });
  }

  edit() {
    const newsId = this.news.id; // Assuming you have an 'id' property in your 'news' object
    this.router.navigate(['news', newsId, 'edit']);
  }

  openDeleteModal(): void {
    const modalRef = this.modalService.open(DeleteNewsComponent);

    modalRef.componentInstance.news = this.news; // Pass data to the DeleteNewsComponent

    modalRef.result.then((result) => {
      // Handle the result after the modal is closed
      if (result === 'delete') {
        this.deleteNews();
      }
    });
  }

  deleteNews(): void {
    // Implement the delete logic here
    const id = +this.route.snapshot.paramMap.get('id')!;
    this.newsService.deleteeNews(id.toString()).subscribe({
      next: (result) => {
        // Handle the result after successful deletion
        this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
          this.router.navigate(['news']);
        });
        // Optionally, navigate to a different route or perform other actions
      },
      error: (err) => console.error('Error deleting news', err),
    });
  }


}

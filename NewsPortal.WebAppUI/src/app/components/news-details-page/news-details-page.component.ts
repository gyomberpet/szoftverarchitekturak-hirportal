import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { News } from 'src/app/models/news';
import { NewsService } from 'src/app/service/news.service';
import { DeleteNewsComponent } from '../delete-news/delete-news.component';
import { AppComponent } from 'src/app/app.component';
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

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private newsService: NewsService,
    private dialogRef: MatDialog,
    private modalService: NgbModal
  ) {
    /*
    this.route.params.subscribe(params =>
    {
    this.news = this.news.find(m => m.id == params.id)
    if (this.news === undefined){
      app.router.navigate(['movies'])
    }
    })
    */
  }
  delete() {
    this.dialogRef.open(DeleteNewsComponent);
  }
  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id')!;
    this.newsService.getNewsById(id).subscribe({
      next: (res: News) => {
        this.news = res;
        this.newsService.getRandomNewsByCategory(this.news.category.name, 3).subscribe({
          next: (res: News[]) => {
            this.randomNewsList = res.filter(x => x.id !== this.news.id)
          },
          error: (err) => console.error(err),
        });
      },
      error: (err) => console.error(err),
    });

    // Generate a list of 3 random news articles
  }

  /* delete(){
    let modal = this.modalService.open(DeleteNewsComponent, { backdrop: 'static', centered: true });
    (modal.componentInstance as DeleteNewsComponent)
      .initParameters({
        news : this.news
      }, {
        restart: () => {
          modal.close();
        }
      });
     /* modal.componentInstance.restart.subscribe((recievedEntry) => {
        if (recievedEntry === true){
          this.app.movies.splice(this.app.movies.indexOf(this.movie),1);
          this.app.router.navigate(['/movies']);
          this.app.saveall();
        }
      });
  }*/
}

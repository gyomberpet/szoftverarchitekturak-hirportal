import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, ReplaySubject } from 'rxjs';
import { News } from 'src/app/models/news';
import { NewsRequestParams } from 'src/app/models/newsRequestParams';
import { NewsService } from 'src/app/service/news.service';
import { NewsCategoryService } from 'src/app/service/news-category.service';
import { NewsCategory } from 'src/app/models/newsCategory';

@Component({
  selector: 'app-create-news',
  templateUrl: './create-news.component.html',
  styleUrls: ['./create-news.component.css'],
})
export class CreateNewsComponent implements OnInit {
  @Input() editingNews: News | null = null;
  selectedFile: File | null;
  news: News = {} as News;
  showAlert: boolean = false;

    constructor(private newsService: NewsService, private route: ActivatedRoute, private newsCategoryService: NewsCategoryService) { }

    categories: NewsCategory[] = [];

    selectedCategory: NewsCategory;
    addingNewCategory = false;
    newCategory: NewsCategory;

  onFileSelected(event: any) {

  constructor(private newsService: NewsService, private route: ActivatedRoute, private newsCategoryService: NewsCategoryService) {}

  categories: NewsCategory[] = [];

  selectedCategory: NewsCategory;
  addingNewCategory = false;
  newCategory: NewsCategory;

  ngOnInit(): void {
    
    this.loadCategories();
    const id = this.route.snapshot.paramMap.get('id')!;
  
    if (id) {
      this.newsService.getNewsById(id).subscribe({
        next: (res: News) => {
          this.editingNews = res;
          this.news = { ...res };
          this.news.endDate = this.news.endDate.split('T')[0]; // Format endDate for the date input
        },
        error: (err) => console.error(err),
      });
    }
  }

  loadCategories() {
    this.newsCategoryService.getCategories().subscribe(
      (data) => {
        this.categories = data;
      },
      (error) => {
        console.error('Error fetching categories:', error);
      }
    );
  }

  onFileSelected(event: any): void {
    this.selectedFile = event.target.files[0] as File;
  }

  createOrUpdateNews(): void {
    if (!this.selectedFile) {
      return;
    }

    this.encodeImageToBase64(this.selectedFile).subscribe({
      next: (res) => {
        const base64image = res;

        this.news = {
          ...this.news,
          startDate: new Date().toISOString(),
          image: { data: base64image },
        };

        const newsObservable = this.editingNews
          ? this.newsService.updateNews(this.news)
          : this.newsService.createNews(this.news);

        newsObservable.subscribe({
          next: (res) => {
            console.log(res);
            this.showAlert = true;
          },
          error: (err) => {
            console.error(err);
          },
        });
      },
      error: (err) => console.error(err),
    });
  }

  encodeImageToBase64(file: File): Observable<string> {
    const result = new ReplaySubject<string>(1);
    const reader = new FileReader();

    reader.onload = (event) =>
      result.next(btoa(event?.target?.result?.toString() || ''));

    reader.readAsBinaryString(file);

    return result;
  }
}

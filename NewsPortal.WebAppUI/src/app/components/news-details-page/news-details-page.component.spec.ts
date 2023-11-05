import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewsDetailsPageComponent } from './news-details-page.component';

describe('NewsDetailsPageComponent', () => {
  let component: NewsDetailsPageComponent;
  let fixture: ComponentFixture<NewsDetailsPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NewsDetailsPageComponent]
    });
    fixture = TestBed.createComponent(NewsDetailsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

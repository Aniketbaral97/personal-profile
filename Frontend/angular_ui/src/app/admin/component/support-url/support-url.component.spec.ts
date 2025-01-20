import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SupportUrlComponent } from './support-url.component';

describe('SupportUrlComponent', () => {
  let component: SupportUrlComponent;
  let fixture: ComponentFixture<SupportUrlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SupportUrlComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SupportUrlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SecSecondComponent } from './sec-second.component';

describe('SecSecondComponent', () => {
  let component: SecSecondComponent;
  let fixture: ComponentFixture<SecSecondComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SecSecondComponent]
    });
    fixture = TestBed.createComponent(SecSecondComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

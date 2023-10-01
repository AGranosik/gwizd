import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SecFirstComponent } from './sec-first.component';

describe('SecFirstComponent', () => {
  let component: SecFirstComponent;
  let fixture: ComponentFixture<SecFirstComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SecFirstComponent]
    });
    fixture = TestBed.createComponent(SecFirstComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

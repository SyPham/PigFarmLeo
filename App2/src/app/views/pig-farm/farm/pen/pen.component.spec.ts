/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PenComponent } from './pen.component';

describe('PenComponent', () => {
  let component: PenComponent;
  let fixture: ComponentFixture<PenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

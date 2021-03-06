/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { Container3Component } from './container3.component';

describe('Container3Component', () => {
  let component: Container3Component;
  let fixture: ComponentFixture<Container3Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Container3Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Container3Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

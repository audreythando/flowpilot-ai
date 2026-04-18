import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkflowsPage } from './workflows-page';

describe('WorkflowsPage', () => {
  let component: WorkflowsPage;
  let fixture: ComponentFixture<WorkflowsPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WorkflowsPage]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WorkflowsPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { Routes } from '@angular/router';
import { DashboardPage } from './features/dashboard/pages/dashboard-page/dashboard-page';
import { WorkflowsPage } from './features/workflows/pages/workflows-page/workflows-page';
import { SubmissionsPage } from './features/submissions/pages/submissions-page/submissions-page';

export const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'dashboard' },
  { path: 'dashboard', component: DashboardPage },
  { path: 'workflows', component: WorkflowsPage },
  { path: 'submissions', component: SubmissionsPage },
  { path: '**', redirectTo: 'dashboard' }
];
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';
import { CreateBlogComponent } from './blog/blog.component';
import { BlogListComponent } from './blogs/blogs.component';
import { NavComponent } from './nav/nav.component';
import { FooterComponent } from './footer/footer.component';
import { DatepickerModule } from 'angular2-material-datepicker';

const appRoutes: Routes = [
	{ path: 'blog/create', component: CreateBlogComponent },
	{ path: '', component: BlogListComponent }
];

@NgModule({
	declarations: [
		CreateBlogComponent,
		BlogListComponent,
		AppComponent,
		NavComponent,
		FooterComponent
	],
	imports: [
		BrowserModule,
		FormsModule,
		HttpModule,
		DatepickerModule,
		RouterModule.forRoot(
			appRoutes,
			{ enableTracing: true } // <-- debugging purposes only
		)
	],
	providers: [],
	bootstrap: [AppComponent]
})
export class AppModule { }

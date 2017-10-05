import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

@Component({
	selector: 'blog-list',
	templateUrl: './blogs.component.html',
	//styleUrls: ['./blog.component.css']
})
export class BlogListComponent implements OnInit {
	title: 'Статьи';
	blogPosts: any[] = [];
	constructor(private httpService: Http) { }
	ngOnInit(): void {
		let filter = { page: 1, pageSize: 15 };
		this.httpService.post('/api/blogs', filter).subscribe(blogPosts => {
			//console.log(blogPosts);
			this.blogPosts = blogPosts.json() as any[];
		});
	}
}
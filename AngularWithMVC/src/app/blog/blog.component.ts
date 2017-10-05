import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Router } from '@angular/router';

@Component({
	selector: 'create-blog',
	templateUrl: './blog.component.html',
	styleUrls: ['./blog.component.css']
})
export class CreateBlogComponent implements OnInit {
	title: 'Добавить статью';
	blog: BlogPost = new BlogPost();
	constructor(private httpService: Http, private router: Router) { }
	ngOnInit(): void { }
	create() {
		this.httpService.post('/api/blog', this.blog).subscribe(blogId => {
			this.router.navigate(['blog/:id', { params: { id: blogId } }]);
		});
	}
}

export class BlogPost {
	subject: string;
	body: string;
	publishDate: Date;
}

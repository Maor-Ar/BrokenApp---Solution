import { Component, OnDestroy, OnInit } from '@angular/core';
import { BlogService } from '../blog.service';
import { NgForm } from '@angular/forms';
import { BlogPost } from '../blog.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.scss']
})
export class BlogComponent implements OnInit, OnDestroy {
  posts: BlogPost[] = [];
  postDetails: BlogPost | null = null;
  newPost: BlogPost = this.getEmptyPost();
  subs: Subscription[] = [];

  constructor(private blogService: BlogService) {}

  ngOnDestroy(): void {
    this.subs.forEach(sub => {
      sub.unsubscribe();
    });
  }

  ngOnInit() {
    this.loadPosts();
  }

  private getEmptyPost(): BlogPost {
    return {
      title: '',
      description: '',
      content: ''
    };
  }

  loadPosts() {
    this.subs.push(this.blogService.getPosts().subscribe({
      next: (posts) => {
        this.posts = posts;
      },
      error: (error) => {
        console.error('Failed to load posts', error);
      }
    }));
  }

  loadPostDetails(id: number | undefined) {
    this.postDetails = this.posts?.find(post => post.id === id) ?? null;    
    if (this.postDetails) {
      return;
    }

    if (!id) return;
    this.subs.push(this.blogService.getPostById(id).subscribe({
      next: (post) => {
        this.postDetails = post;
      },
      error: (error) => {
        console.error('Failed to load post details', error);
      }
    }));
  }

  createPost(form: NgForm) {
    if (form.invalid) return;

    this.blogService.createPost(this.newPost).subscribe({
      next: () => {
        this.loadPosts();
        form.resetForm();
        this.newPost = this.getEmptyPost();
      },
      error: (error) => {
        console.error('Failed to create post', error);
      }
    });
  }
}

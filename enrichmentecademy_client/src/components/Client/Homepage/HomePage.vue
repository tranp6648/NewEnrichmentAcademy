<script setup>
    import Menu from '../Menu/Menu.vue';
    import Footer from '../Footer/Footer.vue'
</script>
<script>


    import { ref, watch, onMounted } from 'vue';
    import { Carousel, Slide } from 'vue3-carousel';
    import 'vue3-carousel/dist/carousel.css';
    export default {
        components: {
            Carousel,
            Slide
        },
        data() {
            return {
                images: [
                    { url: 'https://edupls.themepul.com/wp-content/uploads/2024/03/image-1-1.png', Tittle: 'Featured Courses Our Edupls Theme', title: 'Title 1' },
                    { url: 'https://edupls.themepul.com/wp-content/uploads/2024/03/slider2.png', Tittle: 'Featured Courses Our Edupls Theme', title: 'Title 2' }
                ],
                Student: [
                    { url: 'https://edupls.themepul.com/wp-content/uploads/2024/04/tem-6.png', name: 'Tracy d.wright', Description: 'Grateful for the invaluable  is very partnership with  in our educational endeavors. Education is important for We are truly.' },
                    { url: 'https://edupls.themepul.com/wp-content/uploads/2024/02/Mask-group-1.jpg', name: 'DR.kasime', Description: ' We are truly grateful for the invaluable  is very partnership with  in our educational endeavors. Education is important. ' },
                    { url: 'https://edupls.themepul.com/wp-content/uploads/2024/03/Mask-group-4.png', name: 'DR.kasime', Description: 'The invaluable  is very partnership with  in our educational endeavors. important for We are truly grateful for Us. ' }
                ],
                faqs: [
                    { question: 'What are the different levels of education?', answer: 'Education is important for personal and societal growth, enhancing critical thinking, expanding knowledge and skills, improving career prospects, and promoting social and best School & college.' },
                    { question: 'What is the importance of education?', answer: 'Education is important for personal and societal growth, enhancing critical thinking, expanding knowledge and skills, improving career prospects, and promoting social and best Scholl & collage.' },
                    { question: 'How can I choose  educational institution program?', answer: 'Education is important for personal and societal growth, enhancing critical thinking, expanding knowledge and skills, improving career prospects, and promoting social and best Scholl & collage.' }
                ],
                activeIndex: null,
                counterItems: [
                    { target: 48, title: 'courses COMPLETED', icon: 'fas fa-graduation-cap', counter: 0 },
                    { target: 350, title: 'MEDIA ACTIVITIES', icon: 'fa-solid fa-share-from-square', counter: 0 },
                    { target: 320, title: 'SKILLED EXPERTS', icon: 'fa fa-cogs', counter: 0 },
                    { target: 36, title: 'HAPPY STUDENTS', icon: 'fa-solid fa-people-group', counter: 0 }
                ],
                FocusItem:[
                    {target:48,title:'JOBS COMPLETED',counter:0},
                    {target:36,title:'INDUCTORS',counter:0},
                    {target:53,title:'LEARN STUDENTS',counter:0}
                ]
            };
        },
        mounted() {
            this.startCounters();
        },
        methods: {
            startCounters() {
                this.counterItems.forEach(item => {
                    const increment = item.target / (2000 / 100);
                    const interval = setInterval(() => {
                        if (item.counter < item.target) {
                            item.counter += increment;
                            if (item.counter > item.target) {
                                item.counter = item.target
                            }
                        } else {
                            clearInterval(interval)
                        }
                    }, 100);
                }),
                this.FocusItem.forEach(item=>{
                    const increment = item.target / (2000 / 100);
                    const interval = setInterval(() => {
                        if (item.counter < item.target) {
                            item.counter += increment;
                            if (item.counter > item.target) {
                                item.counter = item.target
                            }
                        } else {
                            clearInterval(interval)
                        }
                    }, 100);
                })
            },
            prevSlide() {
                this.$refs.carousel.prev();
            },
            nextSlide() {
                this.$refs.carousel.next();
            },
            prevStudentPrevBack() {
                this.$refs.CarouselStudent.prev();
            },
            nextStudent() {
                this.$refs.CarouselStudent.next();
            },
            toggle(index) {
                this.activeIndex = this.activeIndex === index ? null : index;
            },
            scrollToTop(){
                window.scrollTo({
                    top:0,
                    behavior:'smooth'
                })
            }
        }
    };
</script>
<template>
    <Menu />
    <div class="edupls-template-home" style="z-index: -1;position: absolute;left: -1px;">
        <div class="elementor elementor-2545">
            <section
                class="elementor-section elementor-top-section elementor-element elementor-element-eb3190d elementor-section-full_width elementor-section-height-default elementor-section-height-default">
                <div class="elementor-container elementor-column-gap-no">
                    <div
                        class="elementor-column elementor-col-100 elementor-top-column elementor-element elementor-element-859c485">
                        <div class="elementor-widget-wrap elementor-element-populated">
                            <div
                                class="elementor-element elementor-element-2cc5988 elementor-widget elementor-widget-slider_one_widget">
                                <div class="elementor-widget-container">
                                    <div class="slider-section-wrapper">
                                        <div class="slider-items slick-initialized slick-slider" id="slider1377">
                                            <button class="prev slick-arrow" @click="prevSlide">
                                                <i class="fas fa-arrow-left"></i>
                                            </button>
                                            <div class="slick-list draggable">
                                                <div class="slick-track" style="opacity: 1">
                                                    <Carousel :autoplay="9000" :wrap-around="true" ref="carousel">
                                                        <Slide v-for="(image, index) in images" :key="index"
                                                            class="slide">
                                                            <img :src="image.url" :alt="image.alt" />
                                                            <div class="slider-table">
                                                                <div class="slider-table-cell">
                                                                    <div class="container">
                                                                        <div class="row">
                                                                            <div
                                                                                class="slider-column col-xl-8 col-lg-8 col-md-11">
                                                                                <div class="slider-content-box">
                                                                                    <div class="slide-stitle">
                                                                                        <span>35% Off</span>

                                                                                        Learn from today
                                                                                    </div>
                                                                                    <div class="slide-title">
                                                                                        Featured Courses Our Edupls
                                                                                        Theme
                                                                                    </div>
                                                                                    <div class="slide-dec">
                                                                                        We believe that with the right
                                                                                        guidance, support, and mindset,
                                                                                        you can accomplish anything you
                                                                                        set your.
                                                                                    </div>
                                                                                    <div class="slider-button-wrapper">
                                                                                        <a href=""
                                                                                            class="theme-btns">Make
                                                                                            Appointment</a>
                                                                                        <div
                                                                                            class="slider-video-button">
                                                                                            <a href="" class="play-btn">
                                                                                                <i
                                                                                                    class="fas fa-play"></i>
                                                                                            </a>
                                                                                            <span
                                                                                                style="position: relative;top: -48px;left: 44px">Play
                                                                                                Now</span>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <ul class="slider-cat-box">
                                                                                <li>
                                                                                    <span class="slider-cat-icon">
                                                                                        <i
                                                                                            class="flaticon flaticon-maintenance"></i>
                                                                                    </span>
                                                                                    <span
                                                                                        class="slider-cat-tex" style="font-size: 14px;">Academic
                                                                                        Enrichment</span>
                                                                                </li>
                                                                                <li>
                                                                                    <span class="slider-cat-icon">
                                                                                        <i
                                                                                            class="flaticon flaticon-maintenance"></i>
                                                                                    </span>
                                                                                    <span class="slider-cat-tex" style="font-size: 14px;">Best
                                                                                        Online Learning</span>
                                                                                </li>
                                                                                <li>
                                                                                    <span class="slider-cat-icon">
                                                                                        <i
                                                                                            class="flaticon flaticon-maintenance"></i>
                                                                                    </span>
                                                                                    <span
                                                                                        class="slider-cat-tex" style="font-size: 14px;">Personalized
                                                                                        Learning</span>
                                                                                </li>
                                                                                <li>
                                                                                    <span class="slider-cat-icon">
                                                                                        <i
                                                                                            class="flaticon flaticon-maintenance"></i>
                                                                                    </span>
                                                                                    <span class="slider-cat-tex" style="font-size: 14px;">Yet
                                                                                        Student Support</span>
                                                                                </li>
                                                                            </ul>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </Slide>
                                                    </Carousel>
                                                </div>
                                            </div>
                                            <button class="next slick-arrow" @click="prevSlide">
                                                <i class="fas fa-arrow-right"></i>
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <section
                class="elementor-section elementor-top-section elementor-element elementor-element-cd6b8ef elementor-section-boxed elementor-section-height-default elementor-section-height-default">
                <div class="elementor-container elementor-column-gap-no" style="margin-left: 19vh;">
                    <div
                        class="elementor-column elementor-col-100 elementor-top-column elementor-element elementor-element-715e0a9">
                        <div class="elementor-widget-wrap elementor-element-populated">
                            <div
                                class="elementor-element elementor-element-ef158ea elementor-widget elementor-widget-edupls_title">
                                <div class="elementor-widget-container">
                                    <div class="container">
                                        <div class="edupls-section-title-wrapper">
                                            <div class="edupls-section-title-content position-relative">
                                                <span class="edupls-section-small-title">

                                                    Our services
                                                </span>
                                                <h2 class="edupls-section-title">
                                                    Service We Provide </h2>
                                                <div class="edupls-section-description" style="color: #7B7E86;font-size: 18px;">

                                                    Access a wealth of educational resources including e book study guide
                                                    and multimedia content.our respositorey
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="elementor-element elementor-element-c2b58b3 elementor-widget elementor-widget-services_two_widget"
                                style="margin-left: -1vh;">
                                <div class="elementor-widget-container">
                                    <div class="container">
                                        <div class="row">
                                            <div class="col-xl-4 col-lg-4 col-md-6">
                                                <div class="service-two-box">
                                                    <div class="service-two-icon">
                                                        <img src="./4762311.png" alt="">
                                                    </div>
                                                    <div class="service-two-content">
                                                        <h5 class="service-two-title">

                                                            Our Best Courses Help
                                                        </h5>
                                                        <div class="service-two-des"
                                                            style="font-size: 16px;width: 48vh;color: #7B7E86;line-height: 27px">

                                                            Entrust full-cycle implementation of software product to
                                                            experienced.
                                                        </div>
                                                    </div>
                                                    <div class="service-two-btn">
                                                        <a href="" class="theme-btns">

                                                            Read More
                                                            <i class="fas fa-arrow-right"></i>
                                                        </a>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-xl-4 col-lg-4 col-md-6">
                                                <div class="service-two-box">
                                                    <div class="service-two-icon">
                                                        <img src="./4762311.png" alt="">
                                                    </div>
                                                    <div class="service-two-content">
                                                        <h5 class="service-two-title">

                                                            Our Best Courses Help
                                                        </h5>
                                                        <div class="service-two-des"
                                                            style="font-size: 16px;width: 48vh;color: #7B7E86;line-height: 27px">

                                                            Entrust full-cycle implementation of software product to
                                                            experienced.
                                                        </div>
                                                    </div>
                                                    <div class="service-two-btn">
                                                        <a href="" class="theme-btns">

                                                            Read More
                                                            <i class="fas fa-arrow-right"></i>
                                                        </a>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-xl-4 col-lg-4 col-md-6">
                                                <div class="service-two-box">
                                                    <div class="service-two-icon">
                                                        <img src="./4762311.png" alt="">
                                                    </div>
                                                    <div class="service-two-content">
                                                        <h5 class="service-two-title">

                                                            Our Best Courses Help
                                                        </h5>
                                                        <div class="service-two-des"
                                                            style="font-size: 16px;width: 48vh;color: #7B7E86;line-height: 27px">

                                                            Entrust full-cycle implementation of software product to
                                                            experienced.
                                                        </div>
                                                    </div>
                                                    <div class="service-two-btn">
                                                        <a href="" class="theme-btns">

                                                            Read More
                                                            <i class="fas fa-arrow-right"></i>
                                                        </a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <section
                class="elementor-section elementor-top-section elementor-element elementor-element-922de5d elementor-section-content-middle elementor-section-boxed elementor-section-height-default elementor-section-height-default">
                <div class="elementor-container elementor-column-gap-no">
                    <div class="elementor-column elementor-col-50 elementor-top-column elementor-element elementor-element-9db9355"
                        style="margin-right: 9vh">
                        <div class="elementor-widget-wrap elementor-element-populated">
                            <div
                                class="elementor-element elementor-element-da96feb elementor-widget elementor-widget-image">
                                <div class="elementor-widget-container">
                                    <img src="https://edupls.themepul.com/wp-content/uploads/2024/03/about2.png" alt="">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div
                        class="elementor-column elementor-col-50 elementor-top-column elementor-element elementor-element-71fe211">
                        <div class="elementor-widget-wrap elementor-element-populated">
                            <div
                                class="elementor-element elementor-element-17c6b80 elementor-widget elementor-widget-edupls_title">
                                <div class="elementor-widget-container">
                                    <div class="container">
                                        <div class="edupls-section-title-wrapper">
                                            <div class="edupls-section-title-content position-relative">
                                                <span class="edupls-section-small-title">
                                                    More About Us </span>
                                                <h2 class="edupls-section-title">

                                                    We the focus and offerin education platform.
                                                </h2>
                                                <div class="edupls-section-description" style="color: #7B7E86;font-size: 18px;">

                                                    We the focus and offerin education platform. to enhance your
                                                    knowledge and skills, whether you're pursuing a certificate, degree,
                                                    or seeking professional development designed to meet the specific
                                                    educational.
                                                </div>
                                                <div class="elementor-element elementor-element-067901c elementor-widget elementor-widget-call_to_action"
                                                    style="margin-top: 12px;">
                                                    <div class="elementor-widget-container">
                                                        <div class="container">
                                                            <div class="cta-button-wrapper">
                                                                <a href="" class="theme-btns">
                                                                    Make Appointment
                                                                    <i class="fas fa-arrow-right"></i>

                                                                </a>
                                                                <div class="cta_button-area">
                                                                    <div class="cta-button-icon">
                                                                        <i class="fas fa-phone-alt"></i>
                                                                    </div>
                                                                    <div class="cta-button-content">
                                                                        <div class="cta-button-title"
                                                                            style="color: #7B7E86;">
                                                                            Call us anytime
                                                                        </div>
                                                                        <div class="cta-button-number">
                                                                            +256 21458.2146
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <section
                class="elementor-section elementor-top-section elementor-element elementor-element-322b289 elementor-section-boxed elementor-section-height-default elementor-section-height-default">
                <div class="elementor-container elementor-column-gap-no">
                    <div
                        class="elementor-column elementor-col-100 elementor-top-column elementor-element elementor-element-e7cccbc">
                        <div class="elementor-widget-wrap elementor-element-populated">
                            <div
                                class="elementor-element elementor-element-3950226 elementor-widget elementor-widget-edupls_title">
                                <div class="elementor-widget-container">
                                    <div class="container">
                                        <div class="edupls-section-title-wrapper">
                                            <div class="edupls-section-title-content position-relative">
                                                <span class="edupls-section-small-title">
                                                    courses plan </span>
                                                <h2 class="edupls-section-title">

                                                    Our Most popular Courses
                                                </h2>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div
                                class="elementor-element elementor-element-6ea431e elementor-widget elementor-widget-courses_two_widget">
                                <div class="elementor-widget-container">
                                    <div class="courses-two-wrapper">
                                        <div class="container">
                                            <div class="courses-two-tab-menu-wrap">
                                                <ul class="nav tab-menu-wrapper">
                                                    <li class="nav-item">
                                                        <button id="all-courses-1084566" class="nav-link active">
                                                            All
                                                        </button>
                                                    </li>
                                                    <li class="nav-item">
                                                        <button id="all-courses-1084566" class="nav-link ">
                                                            Business
                                                        </button>
                                                    </li>
                                                    <li class="nav-item">
                                                        <button id="all-courses-1084566" class="nav-link ">
                                                            Calculus
                                                        </button>
                                                    </li>
                                                    <li class="nav-item">
                                                        <button id="all-courses-1084566" class="nav-link ">
                                                            Finance
                                                        </button>
                                                    </li>
                                                    <li class="nav-item">
                                                        <button id="all-courses-1084566" class="nav-link ">
                                                            Marketing
                                                        </button>
                                                    </li>
                                                </ul>
                                            </div>
                                            <div class="tab-content" id="myTabContent-1084566">
                                                <div class="tab-pane  active show">
                                                    <div class="row">
                                                        <div class="col-lg-4 col-md-6 col-12">
                                                            <div class="courses-two-box">
                                                                <div class="courses-two-image">
                                                                    <img src="https://edupls.themepul.com/wp-content/uploads/2019/05/1_0002_18-1-1.jpg"
                                                                        width="1400" height="860" alt="">
                                                                    <div class="courses-two-category">
                                                                        <a href="">Affiliate Marketing</a>
                                                                    </div>
                                                                </div>
                                                                <div class="courses-two-content-area">
                                                                    <div class="courses-two-top-area">
                                                                        <div class="courses-two-author-info">
                                                                            <div class="courses-two-author-img"
                                                                                style="margin-left: 21px;">
                                                                                <div class="tutor-avatar">
                                                                                    <div
                                                                                        class="tutor-ratio tutor-ratio-1x1">
                                                                                        <img src="https://edupls.themepul.com/wp-content/uploads/2024/04/Rectangle-2895-1-150x150.png"
                                                                                            alt="">
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="courses-two-author-name">
                                                                                <a href="">
                                                                                    Edupls </a>
                                                                            </div>
                                                                        </div>
                                                                        <div class="courses-two-lesson">
                                                                            <i class="fas fa-book"></i>

                                                                            Lesson 6
                                                                        </div>
                                                                    </div>
                                                                    <h4 class="courses-two-title"
                                                                        style="margin-left: 14px;">
                                                                        <a href=""
                                                                            style="color: #1c1c1c;font-weight: bold">Nutrition:
                                                                            Build Your Perfect Diet & Meal Plans</a>
                                                                    </h4>
                                                                    <div class="courses-two-bottom-area"
                                                                        style="margin-left: 14px;">
                                                                        <div class="courses-two-price">
                                                                            <span
                                                                                class="woocommerce-Price-amount amount">
                                                                                <bdi style="color: #7B7E86;">
                                                                                    20.00
                                                                                    <span
                                                                                        class="woocommerce-Price-currencySymbol">$</span>
                                                                                </bdi>
                                                                            </span>
                                                                        </div>
                                                                        <!-- <div class="courses-two-ratting">
                                                                            <div class="tutor-course-ratings tutor-mb-8">
                                                                                <div class="tutor-ratings">
                                                                                    <div class="tutor-ratings-stars">
                                                                                        <span class="tutor-icon-star-bold" ></span>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div> -->
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div
                                class="elementor-element elementor-element-f5b6521 elementor-widget elementor-widget-edupls_theme_button">
                                <div class="elementor-widget-container">
                                    <div class="container">
                                        <div class="edupls-button-wrapper">
                                            <div class="edupls-botton">
                                                <a href="" class="theme-btns">

                                                    Explore Courses
                                                    <i class="fas fa-arrow-right"></i>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <section
                class="elementor-section elementor-top-section elementor-element elementor-element-ff64027 elementor-section-boxed elementor-section-height-default elementor-section-height-default">
                <div class="elementor-container elementor-column-gap-no">
                    <div
                        class="elementor-column elementor-col-50 elementor-top-column elementor-element elementor-element-44f87b3">
                        <div class="elementor-widget-wrap elementor-element-populated">
                            <div
                                class="elementor-element elementor-element-e9c43ca elementor-widget elementor-widget-edupls_title">
                                <div class="elementor-widget-container">
                                    <div class="container">
                                        <div class="edupls-section-title-wrapper">
                                            <div class="edupls-section-title-content position-relative">
                                                <span class="edupls-section-small-title">
                                                    way Choses Us </span>
                                                <h2 class="edupls-section-title" style="width: 54%;">

                                                    We the focus and offerin your education platform See
                                                </h2>
                                                <div class="edupls-section-description" style="color: #fff;width: 50%;font-size: 15px;">

                                                    Discover comprehensive programs and courses to enhance your
                                                    knowledge and skills, whether you're pursuing a certificate, degree,
                                                    or seeking professional development designed to meet the specific
                                                    educational.
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div
                                class="elementor-element elementor-element-e4af314 elementor-widget elementor-widget-counter_one_widget">
                                <div class="elementor-widget-container">
                                    <div class="counter-one-wrapper counter-box-4199">
                                        <div class="container">
                                            <div class="row" style="max-width:60%">
                                                <div class="col-xl-4 col-lg-4 col-md-6 col-12" v-for="item in FocusItem" :key="item.title">
                                                    <div class="counter-one-items">
                                                        <div class="counter-one-item">
                                                            <div class="counter-one-icon">
                                                                <img src="./job-search.png" alt="">
                                                            </div>
                                                            <div class="count-process">
                                                                <div class="counter-one-number">
                                                                    <h2 class="counter-one-count-timer timer"> {{Math.floor(item.counter)}}</h2>
                                                                    <span>K</span>
                                                                </div>
                                                                <div class="counter-one-counter-title">
                                                                   {{item.title}}
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                              
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <section
                class="elementor-section elementor-top-section elementor-element elementor-element-fd8655e elementor-section-content-middle elementor-section-boxed elementor-section-height-default elementor-section-height-default">
                <div class="elementor-container elementor-column-gap-no">
                    <div
                        class="elementor-column elementor-col-50 elementor-top-column elementor-element elementor-element-dd417ee">
                        <div class="elementor-widget-wrap elementor-element-populated">
                            <div class="elementor-element elementor-element-3c88a46 elementor-widget elementor-widget-edupls_title"
                                style="margin-bottom: 17px;">
                                <div class="elementor-widget-container">
                                    <div class="container">
                                        <div class="edupls-section-title-wrapper">
                                            <div class="edupls-section-title-content position-relative">
                                                <span class="edupls-section-small-title">
                                                    Get Free Now </span>
                                                <h2 class="edupls-section-title" style="width: 61%;">

                                                    Register Now & Get Free Courses Online
                                                </h2>
                                                <div class="edupls-section-description"
                                                    style="width: 50%;line-height:133%;color: #7B7E86;font-size: 14px;">

                                                    Register Now & Get Free Courses Online by instructing and guiding
                                                    students, facilitating learning, providing support and
                                                    encouragement, and fostering a positive is back to online new
                                                    courses
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div
                                    class="elementor-element elementor-element-bd936f5 elementor-widget elementor-widget-shortcode">
                                    <div class="elementor-widget-container">
                                        <div class="elementor-shortcode">
                                            <div class="wpcf7 js" id="wpcf7-f2773-p2545-o1">
                                                <form action="">
                                                    <div class="contact-form-one" style="max-width: 50%;">
                                                        <div class="row">
                                                            <div class="col-lg-6 col-md-6 col-12">
                                                                <div class="form-input-area">
                                                                    <span class="wpcf7-form-control-wrap">
                                                                        <input type="text"
                                                                            class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required"
                                                                            placeholder="Your Name">
                                                                    </span>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-6 col-md-6 col-12">
                                                                <div class="form-input-area">
                                                                    <span class="wpcf7-form-control-wrap">
                                                                        <input type="text"
                                                                            class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required"
                                                                            placeholder="Your Address">
                                                                    </span>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-12 col-md-12 col-12">
                                                                <div class="form-input-area">
                                                                    <span class="wpcf7-form-control-wrap">
                                                                        <input type="text"
                                                                            class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required"
                                                                            placeholder="Subject">
                                                                    </span>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-12 col-md-12 col-12">
                                                                <div class="form-input-area message">
                                                                    <span class="wpcf7-form-control-wrap">
                                                                        <textarea name="" cols="10" rows="5"
                                                                            class="wpcf7-form-control wpcf7-textarea wpcf7-validates-as-required"
                                                                            placeholder="Your Message" id=""></textarea>
                                                                    </span>
                                                                </div>
                                                                <div class="contact-form-one-button button">
                                                                    <input type="submit"
                                                                        class="wpcf7-form-control wpcf7-submit has-spinner form-btn"
                                                                        value="Send Here">
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </form>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <section
                class="elementor-section elementor-top-section elementor-element elementor-element-640a2e8 elementor-section-boxed elementor-section-height-default elementor-section-height-default">
                <div class="elementor-container elementor-column-gap-no">
                    <div
                        class="elementor-column elementor-col-100 elementor-top-column elementor-element elementor-element-acf464a">
                        <div class="elementor-widget-wrap elementor-element-populated">
                            <section
                                class="elementor-section elementor-inner-section elementor-element elementor-element-8c8df48 elementor-section-boxed elementor-section-height-default elementor-section-height-default">
                                <div class="elementor-container elementor-column-gap-no">
                                    <div
                                        class="elementor-column elementor-col-50 elementor-inner-column elementor-element elementor-element-5dc0bd5">
                                        <div class="elementor-widget-wrap elementor-element-populated">
                                            <div
                                                class="elementor-element elementor-element-39678a7 elementor-widget elementor-widget-edupls_title">
                                                <div class="elementor-widget-container">
                                                    <div class="container">
                                                        <div class="edupls-section-title-wrapper">
                                                            <div class="edupls-section-title-content position-relative">
                                                                <span class="edupls-section-small-title">
                                                                    Student feedback </span>
                                                                <h2 class="edupls-section-title">
                                                                    Our Student feedback </h2>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <div
                                        class="elementor-column elementor-col-50 elementor-inner-column elementor-element elementor-element-e647870">
                                        <div class="elementor-widget-wrap">

                                        </div>
                                    </div>
                                </div>
                            </section>
                            <div
                                class="elementor-element elementor-element-0829275 elementor-widget elementor-widget-Testimonial_Two_Widget">
                                <div class="elementor-widget-container">
                                    <div class="testi-v2-wrapper">
                                        <div class="container">
                                            <div class="no-row slick-initialized slick-slider">
                                                <div class="slick-list draggable">
                                                    <div class="slick-track">
                                                        <Carousel :itemsToShow="1.75" :wrap-around="true"
                                                            :transition="500" ref="CarouselStudent">
                                                            <Slide v-for="(students, index) in Student" :key="index">
                                                                <div class="testi-v2-item-box" style="width: 96%;">
                                                                    <div class="image-wrap">
                                                                        <img :src="students.url" alt=""
                                                                            class="attachment-full size-full">
                                                                    </div>
                                                                    <div class="testi-v2-info">
                                                                        <h6 class="testi-v2-name">
                                                                            {{students.name}}
                                                                            <span
                                                                                class="testi-v2-designation">/Student</span>
                                                                        </h6>
                                                                        <div class="testi-v2-des"
                                                                            style="width: 93%;color: #7B7E86;font-size: 15px;">
                                                                            {{students.Description}}
                                                                        </div>
                                                                        <div class="testi-v2-share">
                                                                            <i class="fa-regular fa-star"></i>
                                                                            <i class="fa-regular fa-star"></i>
                                                                            <i class="fa-regular fa-star"></i>
                                                                            <i class="fa-regular fa-star"></i>
                                                                            <i class="fa-regular fa-star"></i>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </Slide>
                                                        </Carousel>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="testi-v2-arrow  gap-3">
                                                <button class="testi-v2-prev slick-arrow" @click="prevStudentPrevBack">
                                                    <i class="fas fa-arrow-left"></i>
                                                    PREV
                                                </button>
                                                <button class="testi-v2-next slick-arrow" @click="nextStudent">
                                                    NEXT
                                                    <i class="fas fa-arrow-right"></i>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <section
                class="elementor-section elementor-top-section elementor-element elementor-element-3997764 elementor-section-content-middle elementor-section-boxed elementor-section-height-default elementor-section-height-default">
                <div class="elementor-container elementor-column-gap-no">
                    <div
                        class="elementor-column elementor-col-50 elementor-top-column elementor-element elementor-element-0c45e2e">
                        <div class="elementor-widget-wrap elementor-element-populated">
                            <div
                                class="elementor-element elementor-element-cffd45f elementor-widget elementor-widget-edupls_title">
                                <div class="elementor-widget-container">
                                    <div class="container">
                                        <div class="edupls-section-title-wrapper" style="justify-content: flex-start;">
                                            <div class="edupls-section-title-content position-relative">
                                                <span class="edupls-section-small-title">
                                                    Why Choose Us? </span>
                                                <h2 class="edupls-section-title">
                                                    Frequently Asked Question? </h2>
                                                <div class="edupls-section-description"
                                                    style="width: 49%;color: #7B7E86;font-size: 16px;">

                                                    Teachers play a critical role in education by instructing and
                                                    guiding students, facilitating learning, providing support and
                                                    encouragement, and fostering a positive is back to online new
                                                    courses
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="elementor-element elementor-element-4fc79d1 elementor-widget elementor-widget-accordion_Widget"
                                    style="max-width: 50%;">
                                    <div class="elementor-widget-container">
                                        <div class="edups-accordion-wraper">
                                            <div class="container">
                                                <div class="accordion faq-accordion" id="eco-faq">
                                                    <div class="accordion-item" v-for="(faq,index) in faqs"
                                                        :key="index">
                                                        <div class="accordion-header" :id="'faq' + index">
                                                            <button type="button" class="accordion-button"
                                                                :class="{ 'collapsed': activeIndex !== index }"
                                                                style="font-weight: bold;border-bottom: none;transition: all ease 0.5s;"
                                                                @click="toggle(index)">

                                                                {{ faq.question }}
                                                            </button>
                                                        </div>
                                                        <div id="faq-item-16871" class="accordion-collapse collapse  "
                                                            :class="{ 'show': activeIndex === index }"
                                                            style="transition: all ease 0.5s;visibility: visible;">
                                                            <div class="accordion-body" style="color: #7B7E86;font-size: 16px;">

                                                                {{ faq.answer }}
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- <div class="accordion faq-accordion" id="eco-faq">
                                                    <div class="accordion-item">
                                                        <div class="accordion-header" id="faq1">
                                                            <button type="button" class="accordion-button collapsed" style="font-weight: bold;border-bottom: none;">
                                                                
                                    What are the different levels of education?                                
                                                            </button>
                                                        </div>
                                                        <div id="faq-item-16871" class="accordion-collapse collapse ">
                                                            <div class="accordion-body" style="color: #7B7E86;">
                                                                
                                    Education is important for personal and societal growth, enhancing critical thinking, expanding knowledge and skills, improving career prospects, and promoting social and best Scholl & collage.                                
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div> -->
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <section
                class="elementor-section elementor-top-section elementor-element elementor-element-d4d5312 elementor-section-boxed elementor-section-height-default elementor-section-height-default">
                <div class="elementor-container elementor-column-gap-no">
                    <div
                        class="elementor-column elementor-col-100 elementor-top-column elementor-element elementor-element-19f7c28">
                        <div class="elementor-widget-wrap elementor-element-populated">
                            <div
                                class="elementor-element elementor-element-43d9d20 elementor-widget elementor-widget-counter_one_widget">
                                <div class="elementor-widget-container">
                                    <div class="counter-one-wrapper counter-box-413">
                                        <div class="container">
                                            <div class="row">
                                                <div class="col-xl-3 col-lg-6 col-md-6 col-12"
                                                    v-for="item in counterItems" :key="item.title">
                                                    <div class="counter-one-items">
                                                        <div class="counter-one-item">
                                                            <div class="counter-one-icon">
                                                                <i :class="item.icon"></i>
                                                            </div>
                                                            <div class="count-process">
                                                                <div class="counter-one-number">
                                                                    <h2 class="counter-one-count-timer timer">
                                                                        {{Math.floor(item.counter)}}</h2>
                                                                    <span>+</span>
                                                                </div>
                                                                <div class="counter-one-counter-title">
                                                                    {{ item.title }}
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <section
                class="elementor-section elementor-top-section elementor-element elementor-element-6fbed44 elementor-section-boxed elementor-section-height-default elementor-section-height-default">
                <div class="elementor-container elementor-column-gap-no">
                    <div
                        class="elementor-column elementor-col-100 elementor-top-column elementor-element elementor-element-832d108">
                        <div class="elementor-widget-wrap elementor-element-populated">
                            <section
                                class="elementor-section elementor-inner-section elementor-element elementor-element-50bd367 elementor-section-content-bottom elementor-section-boxed elementor-section-height-default elementor-section-height-default">
                                <div class="elementor-container elementor-column-gap-no">
                                    <div class="elementor-column elementor-col-50 elementor-inner-column elementor-element elementor-element-e8a8205"
                                        style="margin-right: 45vh;">
                                        <div class="elementor-widget-wrap elementor-element-populated">
                                            <div
                                                class="elementor-element elementor-element-c266043 elementor-widget elementor-widget-edupls_title">
                                                <div class="elementor-widget-container">
                                                    <div class="container">
                                                        <div class="edupls-section-title-wrapper">
                                                            <div class="edupls-section-title-content position-relative">
                                                                <span class="edupls-section-small-title"
                                                                    style="font-weight: bold;">
                                                                    our best team </span>
                                                                <h2 class="edupls-section-title">
                                                                    Our Most Popular Instructor </h2>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div
                                        class="elementor-column elementor-col-50 elementor-inner-column elementor-element elementor-element-22b55a0">
                                        <div class="elementor-widget-wrap elementor-element-populated">
                                            <div
                                                class="elementor-element elementor-element-096e693 elementor-widget elementor-widget-edupls_theme_button">
                                                <div class="elementor-widget-container">
                                                    <div class="container">
                                                        <div class="edupls-button-wrapper">
                                                            <div class="edupls-botton">
                                                                <a href="" class="theme-btns">
                                                                    More Team
                                                                    <i class="fas fa-arrow-right"></i>
                                                                </a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </section>
                            <div
                                class="elementor-element elementor-element-59abe67 elementor-widget elementor-widget-Team_Four_Widget">
                                <div class="elementor-widget-container">
                                    <div class="team-v4-wrapper">
                                        <div class="container">
                                            <div class="row" id="team-2990">
                                                <div class="col-xl-4 col-lg-4 col-md-6 col-12">
                                                    <div class="team-v4-item">
                                                        <div class="team-v4-image img-hover">
                                                            <img src="https://edupls.themepul.com/wp-content/uploads/2024/04/team1.png"
                                                                width="430" height="520" alt="">
                                                            <div class="team-v4-share-box">
                                                                <div class="team-v4-shear-plus-icon">
                                                                    <i class="fa-solid fa-share"></i>
                                                                </div>
                                                                <ul class="team-v4-icon">
                                                                    <li>
                                                                        <a href="" class="social">
                                                                            <i class="fab fa-facebook-f"></i>
                                                                        </a>
                                                                    </li>
                                                                    <li>
                                                                        <a href="" class="social">
                                                                            <i class="fab fa-twitter"></i>
                                                                        </a>
                                                                    </li>
                                                                    <li>
                                                                        <a href="" class="social">
                                                                            <i class="fab fa-linkedin-in"></i>
                                                                        </a>
                                                                    </li>
                                                                    <li>
                                                                        <a href="" class="social">
                                                                            <i class="fab fa-instagram"></i>
                                                                        </a>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                        </div>
                                                        <div class="team-v4-content">
                                                            <h6 class="team-v4-title">
                                                                <a href="" style="font-weight: bold;">Rebes Weilms</a>
                                                            </h6>
                                                            <span class="team-v4-stitle">Founder & CEO</span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-4 col-lg-4 col-md-6 col-12">
                                                    <div class="team-v4-item">
                                                        <div class="team-v4-image img-hover">
                                                            <img src="https://edupls.themepul.com/wp-content/uploads/2024/04/team1.png"
                                                                width="430" height="520" alt="">
                                                            <div class="team-v4-share-box">
                                                                <div class="team-v4-shear-plus-icon">
                                                                    <i class="fa-solid fa-share"></i>
                                                                </div>
                                                                <ul class="team-v4-icon">
                                                                    <li>
                                                                        <a href="" class="social">
                                                                            <i class="fab fa-facebook-f"></i>
                                                                        </a>
                                                                    </li>
                                                                    <li>
                                                                        <a href="" class="social">
                                                                            <i class="fab fa-twitter"></i>
                                                                        </a>
                                                                    </li>
                                                                    <li>
                                                                        <a href="" class="social">
                                                                            <i class="fab fa-linkedin-in"></i>
                                                                        </a>
                                                                    </li>
                                                                    <li>
                                                                        <a href="" class="social">
                                                                            <i class="fab fa-instagram"></i>
                                                                        </a>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                        </div>
                                                        <div class="team-v4-content">
                                                            <h6 class="team-v4-title">
                                                                <a href="" style="font-weight: bold;">Rebes Weilms</a>
                                                            </h6>
                                                            <span class="team-v4-stitle">Founder & CEO</span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-4 col-lg-4 col-md-6 col-12">
                                                    <div class="team-v4-item">
                                                        <div class="team-v4-image img-hover">
                                                            <img src="https://edupls.themepul.com/wp-content/uploads/2024/04/team1.png"
                                                                width="430" height="520" alt="">
                                                            <div class="team-v4-share-box">
                                                                <div class="team-v4-shear-plus-icon">
                                                                    <i class="fa-solid fa-share"></i>
                                                                </div>
                                                                <ul class="team-v4-icon">
                                                                    <li>
                                                                        <a href="" class="social">
                                                                            <i class="fab fa-facebook-f"></i>
                                                                        </a>
                                                                    </li>
                                                                    <li>
                                                                        <a href="" class="social">
                                                                            <i class="fab fa-twitter"></i>
                                                                        </a>
                                                                    </li>
                                                                    <li>
                                                                        <a href="" class="social">
                                                                            <i class="fab fa-linkedin-in"></i>
                                                                        </a>
                                                                    </li>
                                                                    <li>
                                                                        <a href="" class="social">
                                                                            <i class="fab fa-instagram"></i>
                                                                        </a>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                        </div>
                                                        <div class="team-v4-content">
                                                            <h6 class="team-v4-title">
                                                                <a href="" style="font-weight: bold;">Rebes Weilms</a>
                                                            </h6>
                                                            <span class="team-v4-stitle">Founder & CEO</span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <section
                class="elementor-section elementor-top-section elementor-element elementor-element-4aef234 elementor-section-content-middle elementor-section-boxed elementor-section-height-default elementor-section-height-default">
                <div class="elementor-container elementor-column-gap-no">
                    <div
                        class="elementor-column elementor-col-50 elementor-top-column elementor-element elementor-element-3026452">
                        <div class="elementor-widget-wrap elementor-element-populated">
                            <div
                                class="elementor-element elementor-element-b6f0253 elementor-widget elementor-widget-image">
                                <div class="elementor-widget-container">
                                    <img src="https://edupls.themepul.com/wp-content/uploads/2024/03/Group-1000015287-e1712573821402.png"
                                        class="attachment-full size-full wp-image-2725" width="627" height="623" alt="">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div
                        class="elementor-column elementor-col-50 elementor-top-column elementor-element elementor-element-3d4065a">
                        <div class="elementor-widget-wrap elementor-element-populated">
                            <div
                                class="elementor-element elementor-element-6a4b160 elementor-widget elementor-widget-edupls_title">
                                <div class="elementor-widget-container">
                                    <div class="container">
                                        <div class="edupls-section-title-wrapper">
                                            <div class="edupls-section-title-content position-relative">
                                                <span class="edupls-section-small-title">
                                                    Make An Appointment </span>
                                                <h2 class="edupls-section-title" style="color: #fff;">

                                                    Get a Free Consultancy
                                                    <br>
                                                    Right Now Here!
                                                </h2>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div
                                class="elementor-element elementor-element-e9bcfd8 elementor-widget elementor-widget-call_to_action">
                                <div class="elementor-widget-container">
                                    <div class="container">
                                        <div class="cta-button-wrapper" style="margin-left: 18vh;">
                                            <a href="" class="theme-btns">
                                                Make Appointment
                                                <i class="fas fa-arrow-right"></i>
                                            </a>
                                            <div class="cta_button-area">
                                                <div class="cta-button-icon">
                                                    <i class="fas fa-phone-alt"></i>
                                                </div>
                                                <div class="cta-button-content">
                                                    <div class="cta-button-title"> Need Help? </div>
                                                    <div class="cta-button-number"> +256 21458.2146</div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <section
                class="elementor-section elementor-top-section elementor-element elementor-element-b1cc61a elementor-section-boxed elementor-section-height-default elementor-section-height-default">

                <div class="elementor-container elementor-column-gap-no">
                    <div class="elementor-column elementor-col-50 elementor-top-column elementor-element elementor-element-b08364e"
                        style="max-width: 45%;margin-right: 38px;">
                        <div class="elementor-widget-wrap elementor-element-populated">
                            <div
                                class="elementor-element elementor-element-70419df elementor-widget elementor-widget-image">
                                <div class="elementor-widget-container">
                                    <img src="https://edupls.themepul.com/wp-content/uploads/2024/03/image-4.png"
                                        width="519" height="312" alt="">
                                </div>
                            </div>
                            <div
                                class="elementor-element elementor-element-1e474be elementor-widget elementor-widget-edupls_title">
                                <div class="elementor-widget-container">
                                    <div class="container">
                                        <div class="edupls-section-title-wrapper">
                                            <div class="edupls-section-title-content position-relative">
                                                <div class="edupls-section-description"
                                                    style="width: 71vh;line-height: 153%;color: #7B7E86;font-size: 16px;">

                                                    Gear up for the new academic year with our exclusive Back-to-School
                                                    Specials! Enjoy discounts on a wide range of courses and learnin
                                                    come materials to kickstart your learning journey.""Bundle up and
                                                    save big! Purchase our course bundles and enjoy a 10%discount on
                                                    your total purchase we carere are bulitup postion.
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div
                                class="elementor-element elementor-element-6df360f elementor-widget elementor-widget-edupls_list_widget">
                                <div class="elementor-widget-container">
                                    <div class="edupls_list_wrp">
                                        <div class="container">
                                            <div class="row">
                                                <div class="col-xl-6 col-lg-6 col-md-12 col-12">
                                                    <div class="edupls-list-box-item ">
                                                        <div class="edupls-list-icon">
                                                            <i class="fa-solid fa-circle-check"></i>
                                                        </div>
                                                        <div class="edupls-list-title" style="font-weight: bold;">
                                                            Fast Growing Sells
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-6 col-lg-6 col-md-12 col-12">
                                                    <div class="edupls-list-box-item ">
                                                        <div class="edupls-list-icon">
                                                            <i class="fa-solid fa-circle-check"></i>
                                                        </div>
                                                        <div class="edupls-list-title" style="font-weight: bold;">
                                                            24/7 Quality Services
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-6 col-lg-6 col-md-12 col-12">
                                                    <div class="edupls-list-box-item ">
                                                        <div class="edupls-list-icon">
                                                            <i class="fa-solid fa-circle-check"></i>
                                                        </div>
                                                        <div class="edupls-list-title" style="font-weight: bold;">
                                                            Expert Members
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-6 col-lg-6 col-md-12 col-12">
                                                    <div class="edupls-list-box-item ">
                                                        <div class="edupls-list-icon">
                                                            <i class="fa-solid fa-circle-check"></i>
                                                        </div>
                                                        <div class="edupls-list-title" style="font-weight: bold;">
                                                            Best Quality Services
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div
                        class="elementor-column elementor-col-50 elementor-top-column elementor-element elementor-element-42ac9f0">
                        <div class="elementor-widget-wrap elementor-element-populated">
                            <div
                                class="elementor-element elementor-element-9cdb2e8 elementor-widget elementor-widget-edupls_title">
                                <div class="elementor-widget-container">
                                    <div class="container">
                                        <div class="edupls-section-title-wrapper">
                                            <div class="edupls-section-title-content position-relative">
                                                <span class="edupls-section-small-title" style="font-weight: bold;">
                                                    hOW it wORK </span>
                                                <h2 class="edupls-section-title"
                                                    style="width: 105%;font-weight: 700;font-family: 'Kanit', sans-serif">

                                                    We are focus and offering education platform.
                                                </h2>
                                                <div class="edupls-section-description" style="color: #7B7E86;font-size: 16px;">

                                                    Discover comprehensive programs and courses to enhance your
                                                    knowledge and skills, whether you're pursuing a certificate, degree,
                                                    or seeking professional development designed to meet the specific
                                                    educational.
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div
                                class="elementor-element elementor-element-41774b4 elementor-widget elementor-widget-image">
                                <div class="elementor-widget-container">
                                    <img src="https://edupls.themepul.com/wp-content/uploads/2024/03/Rectangle-2980.png"
                                        width="597" height="352" alt="">
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </section>
            <section
                class="elementor-section elementor-top-section elementor-element elementor-element-4694f18 elementor-section-boxed elementor-section-height-default elementor-section-height-default">
                <div class="elementor-container elementor-column-gap-no">
                    <div
                        class="elementor-column elementor-col-100 elementor-top-column elementor-element elementor-element-6566d82">
                        <div class="elementor-widget-wrap elementor-element-populated">
                            <div
                                class="elementor-element elementor-element-2fd4581 elementor-widget elementor-widget-edupls_title">
                                <div class="elementor-widget-container">
                                    <div class="container">
                                        <div class="edupls-section-title-wrapper">
                                            <div class="edupls-section-title-content position-relative">
                                                <span class="edupls-section-small-title">

                                                    Our Blog
                                                </span>
                                                <h2 class="edupls-section-title">

                                                    Our Lest News & Blog education Details
                                                </h2>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div
                                class="elementor-element elementor-element-254daa8 elementor-widget elementor-widget-Blog_One_Widget">
                                <div class="elementor-widget-container">
                                    <div class="blog-v1-wrapper">
                                        <div class="container">
                                            <div class="row">
                                                <div class="col-xl-4 col-lg-4 col-md-6 col-sm-12 news-block">
                                                    <div class="blog-v1-item-box">
                                                        <div class="blog-v1-image">
                                                            <img src="https://edupls.themepul.com/wp-content/uploads/2024/02/edublog-6.jpg"
                                                                width="773" height="500" alt="">
                                                            <div class="blog-one-date grid">
                                                                <span class="posted-on">
                                                                    <i class="fa-solid fa-calendar-days"></i>
                                                                    <a href="" style="margin-left: 3px;">
                                                                        <time class="entry-date published"
                                                                            datetime="2024-02-12T10:54:36+00:00">February
                                                                            12, 2024</time>
                                                                    </a>
                                                                </span>
                                                            </div>
                                                        </div>
                                                        <div class="blog-v1-content-box">
                                                            <div class="blog-v1-content">
                                                                <h5 class="blog-v1-title">
                                                                    <a href="" style="color: #1c1c1c;">Beyond the Class
                                                                        room for Explore Educational…</a>
                                                                </h5>
                                                                <div class="blog-v1-dec" style="color: #7B7E86;">
                                                                    we are committed to making education more than just
                                                                    a classroom experience.…
                                                                </div>
                                                            </div>
                                                            <div class="blog-v1-bottom">
                                                                <div class="blog-v1-btn">
                                                                    <a href="" class="theme-btns" style="font-weight: bold;">
                                                                        Read More
                                                                        <i class="fas fa-arrow-right"></i>
                                                                    </a>
                                                                </div>
                                                                <div class="blog-v1-comment">
                                                                    <i class="far fa-comments"></i>
                                                                    <span style="color: #7B7E86;">Comment 0</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-4 col-lg-4 col-md-6 col-sm-12 news-block">
                                                    <div class="blog-v1-item-box">
                                                        <div class="blog-v1-image">
                                                            <img src="https://edupls.themepul.com/wp-content/uploads/2024/02/edublog-6.jpg"
                                                                width="773" height="500" alt="">
                                                            <div class="blog-one-date grid">
                                                                <span class="posted-on">
                                                                    <i class="fa-solid fa-calendar-days"></i>
                                                                    <a href="" style="margin-left: 3px;">
                                                                        <time class="entry-date published"
                                                                            datetime="2024-02-12T10:54:36+00:00">February
                                                                            12, 2024</time>
                                                                    </a>
                                                                </span>
                                                            </div>
                                                        </div>
                                                        <div class="blog-v1-content-box">
                                                            <div class="blog-v1-content">
                                                                <h5 class="blog-v1-title">
                                                                    <a href="" style="color: #1c1c1c;">Beyond the Class
                                                                        room for Explore Educational…</a>
                                                                </h5>
                                                                <div class="blog-v1-dec" style="color: #7B7E86;">
                                                                    we are committed to making education more than just
                                                                    a classroom experience.…
                                                                </div>
                                                            </div>
                                                            <div class="blog-v1-bottom">
                                                                <div class="blog-v1-btn">
                                                                    <a href="" class="theme-btns" style="font-weight: bold;">
                                                                        Read More
                                                                        <i class="fas fa-arrow-right"></i>
                                                                    </a>
                                                                </div>
                                                                <div class="blog-v1-comment">
                                                                    <i class="far fa-comments"></i>
                                                                    <span style="color: #7B7E86;">Comment 0</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-4 col-lg-4 col-md-6 col-sm-12 news-block">
                                                    <div class="blog-v1-item-box">
                                                        <div class="blog-v1-image">
                                                            <img src="https://edupls.themepul.com/wp-content/uploads/2024/02/edublog-6.jpg"
                                                                width="773" height="500" alt="">
                                                            <div class="blog-one-date grid">
                                                                <span class="posted-on">
                                                                    <i class="fa-solid fa-calendar-days"></i>
                                                                    <a href="" style="margin-left: 3px;">
                                                                        <time class="entry-date published"
                                                                            datetime="2024-02-12T10:54:36+00:00">February
                                                                            12, 2024</time>
                                                                    </a>
                                                                </span>
                                                            </div>
                                                        </div>
                                                        <div class="blog-v1-content-box">
                                                            <div class="blog-v1-content">
                                                                <h5 class="blog-v1-title">
                                                                    <a href="" style="color: #1c1c1c;">Beyond the Class
                                                                        room for Explore Educational…</a>
                                                                </h5>
                                                                <div class="blog-v1-dec" style="color: #7B7E86;">
                                                                    we are committed to making education more than just
                                                                    a classroom experience.…
                                                                </div>
                                                            </div>
                                                            <div class="blog-v1-bottom">
                                                                <div class="blog-v1-btn">
                                                                    <a href="" class="theme-btns" style="font-weight: bold;">
                                                                        Read More
                                                                        <i class="fas fa-arrow-right"></i>
                                                                    </a>
                                                                </div>
                                                                <div class="blog-v1-comment">
                                                                    <i class="far fa-comments"></i>
                                                                    <span style="color: #7B7E86;">Comment 0</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <Footer />
        </div>
        <div class="to-top" id="back-top" @click="scrollToTop">
            <i class="fa-solid fa-arrow-up"></i>
        </div>
    </div>
</template>

<style>
    @import url('./Homepage.css');

    .slider-table {
        position: absolute;
        top: 54%;
        left: 55%;
        transform: translate(-50%, -50%);
        color: red;

        padding: 10px;

    }

    .slick-item {
        display: flex;
        justify-content: center;
        align-items: center;
        height: 300px;
        /* Adjust as needed */
    }

    .slick-item img {
        max-width: 100%;
        max-height: 100%;
    }

    .slide-wrapper {
        transition: transform 0.5s ease;
        /* Example of CSS transition */
    }

    /* Example of CSS animation */
    .slide-enter-active,
    .slide-leave-active {
        transition: opacity 0.5s ease, transform 0.5s ease;
    }

    .slide-enter,
    .slide-leave-to {
        opacity: 0;
        transform: translateX(100%);
    }
</style>
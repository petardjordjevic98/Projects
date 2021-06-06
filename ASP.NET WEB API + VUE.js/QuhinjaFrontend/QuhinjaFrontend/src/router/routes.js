
 const routes = [
   {
path: '/',
    component: () => import('layouts/MainLayout.vue'),
     children: [
       
       { path: '', component: () => import('pages/Index.vue'),meta : { requiresAuth: true, roles: ['user']} },
       { path: '/dishes', component: () => import('pages/DishesPage.vue'),meta: { requiresAuth: true, roles: ['user'] }},
       { path: '/dish/:id', component: () => import('pages/DishPage.vue'),meta: { requiresAuth: true, roles: ['user'] }},
       { path: '/employees', component: () => import('pages/EmployeesPage.vue'),meta: { requiresAuth: true, roles: ['user'] }},
       { path: '/menu', component: () => import('pages/MenuPage.vue'),meta: { requiresAuth: true, roles: ['user'] }},
       { path: '/recipe/:id', component: () => import('pages/RecipePage.vue'),},
       { path: '/profile', component: () => import('pages/ProfilePage.vue'), meta: { requiresAuth: true, roles: ['user'] } },
       {path: '/addDish', component:()=>import ('pages/AddDishPage.vue'), meta: { requiresAuth: true, roles: ['admin'] } } ,
       {path: '/addRecipe/:id', component: ()=> import('pages/AddRecipePage.vue'), meta: { requiresAuth: true, roles: ['admin'] }}

     ]
   },
   {
     path:'/login',
     component: () => import('layouts/LoginLayout.vue'),
     children:[
        { path : '',name: 'Login',component : () => import('pages/Login.vue')}
     ]
   },

  // Always leave this as last one,
  {
    path: '*',
   component: () => import('pages/Error404.vue')
   }
 ]



export default routes


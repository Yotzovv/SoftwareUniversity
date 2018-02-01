function triangleOfStars(n) {
    for(let i=1;i<=n;i++) {
        console.log('*'.repeat(i));
    }
    for(let b=n-1;b>=1;b--) {
        console.log('*'.repeat(b));
    }
}

triangleOfStars(2);
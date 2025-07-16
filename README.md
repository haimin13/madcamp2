# 🎮 Together Bound: 협동 탈출 대작전

> **"줄로 연결된 두 캐릭터, 완벽한 협동으로 탈출하라!"**  
> 닌자 개구리와 가상 현실 소년이 함께 사과 3개를 먹고 탈출하는 **2인 협동 액션 퍼즐 게임**!

---

## 📌 프로젝트 소개

**Together Bound**는 줄로 연결된 두 플레이어가 **사과를 수집하고 탈출 지점에 도달**해야 클리어할 수 있는 **Unity 기반 2D 횡스크롤 협동 게임**입니다.

- **개발 플랫폼**: Unity 2021, WebGL, Android APK
- **사용 기술**:  
  - Unity (Physics2D, Rigidbody2D, SpringJoint2D)
  - Firebase (Google 로그인, 기록 저장)
  - MariaDB, Node.js 서버 연동
- **주요 기능**:
  - 🪢 줄로 연결된 캐릭터 협동 이동
  - 🍎 사과 3개 수집 시 탈출 가능
  - 🕹️ 키보드 2인용 조작 (A/D/W & 방향키)
  - 🕒 타이머 및 게임 기록 서버 전송
  - 🌐 WebGL 및 APK 배포

---

## 🎮 게임 플레이 방식

1. 플레이어 1 (닌자 개구리)과 플레이어 2 (VR 가이)를 조작하여 이동
2. 줄에 제약을 받으며 사과를 3개 모두 수집
3. 함께 도착지점으로 이동하면 클리어!
4. 기록은 자동으로 서버에 저장되어 랭킹화 가능

---

## 👥 팀원

| 이름 | 역할 |
|------|------|
| 김재헌 | 기획 / Unity 개발 / 서버 연동 / 게임 디자인 |
| (예시) 홍길동 | UI 및 사운드 디자인 |
| (예시) 이영희 | 백엔드 서버 개발 / DB 설계 |

---

## 📸 스크린샷 & 움짤

### 📹 플레이 영상 (20초 이상)
[▶️ 게임 시연 영상 보기](https://drive.google.com/your-demo-video-link)

### 🖼️ 스크린샷

| 장면 설명 | 이미지 |
|-----------|--------|
| 메인 캐릭터 등장 | ![](./images/scene1.png) |
| 사과 수집 장면 | ![](./images/apple.png) |
| 협동 이동 중 | ![](./images/rope.png) |
| 탈출 성공 화면 | ![](./images/clear.png) |

> `./images/` 폴더에 직접 이미지 넣거나, 드라이브 링크 사용 가능

---

## 📦 APK 다운로드

[📥 APK 다운로드 (Google Drive)](https://drive.google.com/your-apk-link)

> Android 기기에서 APK 설치 후 바로 실행 가능  
> APK 직접 첨부 시 `./build/app-release.apk` 경로에 포함

---

## ⚙️ 조작 방법

| Action       | Player 1 | Player 2 |
|--------------|----------|----------|
| Move Left    | A        | ←       |
| Move Right   | D        | →       |
| Jump         | W        | ↑       |
| Hold Down    | S        | ↓       |

> 🎮 줄의 물리 효과 때문에 **협동**하지 않으면 절대 클리어할 수 없습니다!

---

## 🔧 설치 및 실행

### ✅ WebGL (웹 실행)
GitHub Pages 또는 Web Server에서 index.html 실행  
(예: https://your-username.github.io/TogetherBound/)

### ✅ APK 설치
```bash
1. 위의 링크에서 APK 파일 다운로드
2. Android 기기에서 설치 허용
3. 게임 실행!
